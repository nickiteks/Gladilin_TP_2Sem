using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopListImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;

        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(StorageBindingModel storage)
        {
            Storage tempStorage = storage.Id.HasValue ? null : new Storage
            {
                Id = 1
            };
            foreach (var s in source.Storages)
            {
                if (s.StorageName == storage.StorageName && s.Id != storage.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                if (!storage.Id.HasValue && s.Id >= tempStorage.Id)
                {
                    tempStorage.Id = s.Id + 1;
                }
                else if (storage.Id.HasValue && s.Id == storage.Id)
                {
                    tempStorage = s;
                }
            }
            if (storage.Id.HasValue)
            {
                if (tempStorage == null)
                {
                    throw new Exception("Элемент не найден");
                }
                tempStorage.StorageName = storage.StorageName;
            }
            else
            {
                source.Storages.Add(new Storage()
                {
                    Id = tempStorage.Id,
                    StorageName = storage.StorageName
                }
                );
            }
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            foreach (var storage in source.Storages)
            {
                if (model != null)
                {
                    if (storage.Id == model.Id)
                    {
                        result.Add(new StorageViewModel()
                        {
                            Id = storage.Id,
                            StorageName = storage.StorageName,
                            StoragedComponents = source.StorageComponents.Where(sm => sm.StorageId == storage.Id)
                            .ToDictionary(sm => source.Components.FirstOrDefault(c => c.Id == sm.ComponentId).ComponentName, sm => sm.Count)
                        });
                        break;
                    }
                    continue;
                }
                result.Add(new StorageViewModel()
                {
                    Id = storage.Id,
                    StorageName = storage.StorageName,
                    StoragedComponents = source.StorageComponents.Where(sm => sm.StorageId == storage.Id)
                           .ToDictionary(sm => source.Components.FirstOrDefault(c => c.Id == sm.ComponentId).ComponentName, sm => sm.Count)
                });
            }
            return result;
        }
        public void Delete(StorageBindingModel model)
        {
            for (int i = 0; i < source.StorageComponents.Count; ++i)
            {
                if (source.StorageComponents[i].StorageId == model.Id)
                {
                    source.StorageComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddComponentToStorage(StorageAddComponentsBindingModel model)
        {
            if (source.StorageComponents.Count == 0)
            {
                source.StorageComponents.Add(new StorageComponent()
                {
                    Id = 1,
                    ComponentId = model.ComponentId,
                    StorageId = model.StorageId,
                    Count = model.ComponentCount
                });
            }
            else
            {
                var component = source.StorageComponents.FirstOrDefault(sm => sm.StorageId == model.StorageId && sm.ComponentId == model.ComponentId);
                if (component == null)
                {
                    source.StorageComponents.Add(new StorageComponent()
                    {
                        Id = source.StorageComponents.Max(sm => sm.Id) + 1,
                        ComponentId = model.ComponentId,
                        StorageId = model.StorageId,
                        Count = model.ComponentCount
                    });
                }
                else
                    component.Count += model.ComponentCount;
            }
        }
        public bool RemoveComponents(OrderViewModel order)
        {
            if (CheckingStoragedComponents(order))
            {
                var furnitureComponents = source.FurnitureComponents.Where(dm => dm.FurnitureId == order.FurnitureId);
                foreach (var dm in furnitureComponents)
                {
                    int componentCount = dm.Count * order.Count;
                    foreach (var sm in source.StorageComponents)
                    {
                        if (sm.ComponentId == dm.ComponentId && sm.Count >= componentCount)
                        {
                            sm.Count -= componentCount;
                            break;
                        }
                        else if (sm.ComponentId == dm.ComponentId && sm.Count < componentCount)
                        {
                            componentCount -= sm.Count;
                            sm.Count = 0;
                        }
                    }
                }
                return true;
            }
            else
                return false;
        }
        public bool CheckingStoragedComponents(OrderViewModel order)
        {
            var furnitureComponent = source.FurnitureComponents.Where(dm => dm.FurnitureId == order.FurnitureId);
            var componentStorages = new Dictionary<int, int>();
            foreach (var sm in source.StorageComponents)
            {
                if (componentStorages.ContainsKey(sm.ComponentId))
                    componentStorages[sm.ComponentId] += sm.Count;
                else
                    componentStorages.Add(sm.ComponentId, sm.Count);
            }

            foreach (var dm in furnitureComponent)
            {
                if (!componentStorages.ContainsKey(dm.ComponentId) || componentStorages[dm.ComponentId] < dm.Count * order.Count)
                    return false;
            }

            return true;
        }
    }
}
