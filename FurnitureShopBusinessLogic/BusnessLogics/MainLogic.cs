using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Enums;
using FurnitureShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.BusnessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly object locker = new object();
        public MainLogic(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                FurnitureId = model.FurnitureId,
                ClientId = model.ClientId,
                Count = model.Count,
                ClientFIO = model.ClientFIO,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel
                {
                    Id = model.OrderId,                 
                })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    FurnitureId = order.FurnitureId,
                    Count = order.Count,
                    ClientFIO = order.ClientFIO,
                    ImplementerId = model.ImplementerId.Value,
                    ImplementerFIO = model.ImplementerFIO,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {          
                var order = orderLogic.Read(new OrderBindingModel
                {
                    Id = model.OrderId
                })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Выполняется)
                {
                    throw new Exception("Заказ не в статусе \"Выполняется\"");
                }
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    FurnitureId = order.FurnitureId,
                    ClientId = order.ClientId,
                    ClientFIO = order.ClientFIO,
                    Count = order.Count,
                    ImplementerFIO = order.ImplementerFIO,
                    ImplementerId = order.ImplementerId.Value,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    Status = OrderStatus.Готов
                });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                FurnitureId = order.FurnitureId,
                ClientId =order.ClientId,
                ClientFIO = order.ClientFIO,
                ImplementerFIO = order.ImplementerFIO,
                ImplementerId = order.ImplementerId.Value,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
