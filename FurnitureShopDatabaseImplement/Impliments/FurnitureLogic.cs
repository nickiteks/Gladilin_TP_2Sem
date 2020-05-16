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
    public class FurnitureLogic : IFurnitureLogic
    {
        public void CreateOrUpdate(FurnitureBindingModel model)
        {
            using (var context = new FurnitureShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Furniture element = context.Furnitures.FirstOrDefault(rec =>
                       rec.FurnitureName == model.FurnitureName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Furnitures.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                    {
                            element = new Furniture();
                            context.Furnitures.Add(element);
                        }
                        element.FurnitureName = model.FurnitureName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.FurnitureComponents.Where(rec
                           => rec.FurnitureId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.FurnitureComponents.RemoveRange(productComponents.Where(rec =>
                            !model.FurnitureComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.FurnitureComponents[updateComponent.ComponentId].Item2;

                                model.FurnitureComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.FurnitureComponents)
                        {
                            context.FurnitureComponents.Add(new FurnitureComponent
                            {
                                FurnitureId = element.Id,
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(FurnitureBindingModel model)
        {
            using (var context = new FurnitureShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.FurnitureComponents.RemoveRange(context.FurnitureComponents.Where(rec =>
                        rec.FurnitureId == model.Id));
                        Furniture element = context.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Furnitures.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<FurnitureViewModel> Read(FurnitureBindingModel model)
        {
            using (var context = new FurnitureShopDatabase())
            {
                return context.Furnitures
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new FurnitureViewModel
               {
                   Id = rec.Id,
                   FurnitureName = rec.FurnitureName,
                   Price = rec.Price,
                   FurnitureComponents = context.FurnitureComponents
                .Include(recPC => recPC.Component)
               .Where(recPC => recPC.FurnitureId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
