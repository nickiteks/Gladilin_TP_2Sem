using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Enums;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopDatabaseImplement.Impliments
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new FurnitureShopDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }       
                element.ClientId=model.ClientId == 0 ? element.ClientId : model.ClientId;
                element.FurnitureId = model.FurnitureId == 0 ? element.FurnitureId : model.FurnitureId;
                element.Count = model.Count;
                element.ClientFIO = model.ClientFIO;
                element.ImplementerFIO = model.ImplementerFIO;
                element.ImplementerId = model.ImplementerId == 0 ? element.ImplementerId : model.ImplementerId; ;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new FurnitureShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new FurnitureShopDatabase())
            {
                return context.Orders.Where(rec => model == null || rec.Id == model.Id || (rec.DateCreate >= model.DateFrom)
                && (rec.DateCreate <= model.DateTo) || (model.ClientId == rec.ClientId) ||
                (model.FreeOrder.HasValue && model.FreeOrder.Value && !(rec.ImplementerFIO != null)) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == OrderStatus.Выполняется))
                .Include(ord => ord.Furnitures)
                .Select(rec => new OrderViewModel()
                {
                    Id = rec.Id,
                    FurnitureId = rec.FurnitureId,
                    ClientFIO = rec.ClientFIO,
                    ClientId = rec.ClientId,
                    FurnitureName = rec.Furnitures.FurnitureName,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Sum = rec.Sum
                }).ToList();
            }
        }
    }
}
