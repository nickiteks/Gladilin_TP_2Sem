using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopDataBaseImpliment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopDataBaseImpliment.Impliments
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                Order order;
                if (model.Id.HasValue)
                {
                    order = context.Orders.ToList().FirstOrDefault(rec => rec.Id == model.Id);
                    if (order == null)
                        throw new Exception("Элемент не найден");
                }
                else
                {
                    order = new Order();
                    context.Orders.Add(order);
                }
                order.ClientId = model.ClientId;
                order.FurnitureId = model.FurnitureId;
                order.Count = model.Count;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;
                order.Status = model.Status;
                order.Sum = model.Sum;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
                context.SaveChanges();
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                return context.Orders
                .Where(rec => model == null ||
                (model.Id != null && rec.Id == model.Id) ||
                (model.ClientId == rec.ClientId) ||
                (model.DateFrom != null && model.DateTo != null && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                .Include(rec => rec.Furniture)
                .Include(rec => rec.Client)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    FurnitureId = rec.FurnitureId,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.Fio,
                    FurnitureName = rec.Furniture.FurnitureName,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Sum = rec.Sum
                })
                .ToList();
            }
        }
    }
}
