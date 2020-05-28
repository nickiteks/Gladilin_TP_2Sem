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
    public class StorageLogic : IStorageLogic
    {

        public void CreateOrUpdate(StorageBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Storage();
                    context.Storages.Add(element);
                }
                element.StorageName = model.StorageName;
                context.SaveChanges();
            }
        }

        public void Delete(StorageBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                context.StorageComponents.RemoveRange(context.StorageComponents.Where(rec => rec.StorageId == model.Id));
                Storage element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Storages.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                return context.Storages.Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new StorageViewModel
                {
                    Id = rec.Id,
                    StorageName = rec.StorageName,
                    StoragedComponents = context.StorageComponents.Include(recSM => recSM.Component)
                                                           .Where(recSM => recSM.StorageId == rec.Id)
                                                           .ToDictionary(recSM => recSM.Component.ComponentName, recSM => recSM.Count)
                }).ToList();
            }
        }

        public bool RemoveComponents(OrderViewModel order)
        {
            using (var context = new FurnitureShopDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var furnitureComponents = context.FurnitureComponents.Where(dm => dm.FurnitureId == order.FurnitureId).ToList();
                        var storageComponents = context.StorageComponents.ToList();
                        foreach (var component in furnitureComponents)
                        {
                            var componentCount = component.Count * order.Count;
                            foreach (var sm in storageComponents)
                            {
                                if (sm.ComponentId == component.ComponentId && sm.Count >= componentCount)
                                {
                                    sm.Count -= componentCount;
                                    componentCount = 0;
                                    context.SaveChanges();
                                    break;
                                }
                                else if (sm.ComponentId == component.ComponentId && sm.Count < componentCount)
                                {
                                    componentCount -= sm.Count;
                                    sm.Count = 0;
                                    context.SaveChanges();
                                }
                            }
                            if (componentCount > 0)
                                throw new Exception("Не хватает материалов на складах!");
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void AddComponentToStorage(StorageAddComponentBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                var storageComponent = context.StorageComponents
                    .FirstOrDefault(sm => sm.ComponentId == model.ComponentId && sm.StorageId == model.StorageId);
                if (storageComponent != null)
                    storageComponent.Count += model.ComponentCount;
                else
                    context.StorageComponents.Add(new StorageComponent()
                    {
                        ComponentId = model.ComponentId,
                        StorageId = model.StorageId,
                        Count = model.ComponentCount
                    });
                context.SaveChanges();
            }
        }
    }
}
