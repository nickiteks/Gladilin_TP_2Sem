using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Enums;
using FurnitureShopBusinessLogic.HelperModels;
using FurnitureShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.BusnessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IClientLogic clientLogic;
        private readonly object locker = new object();
        public MainLogic(IOrderLogic orderLogic, IClientLogic clientLogic)
        {
            this.orderLogic = orderLogic;
            this.clientLogic = clientLogic;
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
            MailLogic.MailSendAsync(new MailSendInfo
            { 
                MailAddress = clientLogic.Read(new ClientBindingModel 
                { 
                    Id = model.ClientId
                })?[0]?.Email,
                Subject = $"Новый заказ",
                Text = $"Заказ принят."
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
                MailLogic.MailSendAsync(new MailSendInfo 
                { 
                    MailAddress = clientLogic.Read(new ClientBindingModel 
                    { 
                        Id = order.ClientId
                    })?[0]?.Email,
                    Subject = $"Заказ №{order.Id}", 
                    Text = $"Заказ №{order.Id} " +
                    $"передан в работу." 
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
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel 
                { 
                    Id = order.ClientId 
                })?[0]?.Email,
                Subject = $"Заказ №{order.Id}", 
                Text = $"Заказ №{order.Id} готов." 
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
            MailLogic.MailSendAsync(new MailSendInfo
            { 
                MailAddress = clientLogic.Read(new ClientBindingModel
                {
                    Id = order.ClientId 
                })?[0]?.Email,    
                Subject = $"Заказ №{order.Id}",    
                Text = $"Заказ №{order.Id} оплачен."       
            });
        }
    }
}
