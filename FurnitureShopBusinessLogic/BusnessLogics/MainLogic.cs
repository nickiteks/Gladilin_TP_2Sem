﻿using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Enums;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.BusnessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly object locker = new object();
        private readonly IStorageLogic storageLogic;

        public MainLogic(IOrderLogic orderLogic, IStorageLogic storageLogic)
        {
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ClientId = model.ClientId,
                FurnitureId = model.FurnitureId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status!=OrderStatus.Треубются_материалы)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                try 
                {
                    storageLogic.RemoveMaterials(order);
                    orderLogic.CreateOrUpdate(new OrderBindingModel
                    {
                        Id = order.Id,
                        ClientId = order.ClientId,
                        FurnitureId = order.FurnitureId,
                        Count = order.Count,
                        Sum = order.Sum,
                        ClientFIO = order.ClientFIO,
                        ImplementerId = model.ImplementerId.Value,
                        ImplementerFIO = model.ImplementerFIO,
                        DateCreate = order.DateCreate,
                        DateImplement = DateTime.Now,
                        Status = OrderStatus.Выполняется
                    });
                }
                catch
                {
                    orderLogic.CreateOrUpdate(new OrderBindingModel
                    {
                        Id = order.Id,
                        ClientId = order.ClientId,
                        FurnitureId = order.FurnitureId,
                        Count = order.Count,
                        Sum = order.Sum,
                        ClientFIO = order.ClientFIO,
                        ImplementerId = null,
                        ImplementerFIO = null,
                        DateCreate = order.DateCreate,
                        DateImplement = DateTime.Now,
                        Status = OrderStatus.Треубются_материалы
                    });
                }
            }
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
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
                Count = order.Count,
                Sum = order.Sum,
                ImplementerFIO = order.ImplementerFIO,
                ImplementerId = order.ImplementerId.Value,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
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
                ClientId = order.ClientId,
                Count = order.Count,
                Sum = order.Sum,
                ImplementerFIO = order.ImplementerFIO,
                ImplementerId = order.ImplementerId.Value,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }

        public void AddComponents(StorageAddComponentBindingModel model)
        {
            storageLogic.AddComponentToStorage(model);
        }
    }
}
