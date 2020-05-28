using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopFileImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly FileDataListSingleton source;

        public StorageLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(s => s.StorageName == model.StorageName && s.Id != model.Id);
            if (element != null)
                throw new Exception("Уже есть компонент с таким названием");
            if (model.Id.HasValue)
            {
                element = source.Storages.FirstOrDefault(s => s.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                var storageMaterials = source.StorageComponents.Where(sm => sm.StorageId == element.Id).ToList();
                for (int i = 0; i < storageMaterials.Count; i++)
                {
                    if (model.StoragedComponents.ContainsKey(storageMaterials[i].ComponentId))
                        storageMaterials[i].Count = model.StoragedComponents[storageMaterials[i].ComponentId].Item2;
                    else
                        storageMaterials.RemoveAt(i);
                }
                var keysMaterials = model.StoragedComponents.Keys;
                int maxId = source.StorageComponents.Count > 0 ? source.StorageComponents.Count : 0;
                foreach (var k in keysMaterials)
                {
                    if (!source.StorageComponents.Where(sm => sm.StorageId == element.Id).Select(sm => sm.ComponentId).Contains(k))
                        source.StorageComponents.Add(new StorageComponent()
                        {
                            Id = ++maxId,
                            ComponentId = k,
                            StorageId = element.Id,
                            Count = model.StoragedComponents[k].Item2
                        });
                }
            }
            else
            {
                int maxId = source.Storages.Count > 0 ? source.Storages.Max(s => s.Id) : 0;
                element = new Storage { Id = maxId + 1 };
                source.Storages.Add(element);
            }
            element.StorageName = model.StorageName;
        }

        public void Delete(StorageBindingModel model)
        {
            Storage storage = source.Storages.FirstOrDefault(s => s.Id == model.Id);
            if (storage != null)
                source.Storages.Remove(storage);
            else
                throw new Exception("Хранилище не найдено");
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            return source.Storages
            .Where(s => model == null || s.Id == model.Id)
            .Select(s => new StorageViewModel
            {
                Id = s.Id,
                StorageName = s.StorageName,
                StoragedComponents = source.StorageComponents
                    .Where(sm => sm.StorageId == s.Id)
                    .Select(sm => (source.Components.FirstOrDefault(m => m.Id == sm.ComponentId).ComponentName, sm.Count))
                    .ToDictionary(k => source.Components.FirstOrDefault(m => m.ComponentName == k.ComponentName).Id)
            })
            .ToList();
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
        public bool CheckingStoragedComponents(OrderViewModel order)
        {
            var furnitureComponents = source.FurnitureComponents.Where(dm => dm.FurnitureId == order.FurnitureId);
            var componentStorages = new Dictionary<int, int>();
            foreach (var sm in source.StorageComponents)
            {
                if (componentStorages.ContainsKey(sm.ComponentId))
                    componentStorages[sm.ComponentId] += sm.Count;
                else
                    componentStorages.Add(sm.ComponentId, sm.Count);
            }

            foreach (var dm in furnitureComponents)
            {
                if (!componentStorages.ContainsKey(dm.ComponentId) || componentStorages[dm.ComponentId] < dm.Count * order.Count)
                    return false;
            }

            return true;
        }
        public bool RemoveComponents(OrderViewModel order)
        {
            if (CheckingStoragedComponents(order))
            {
                var furnitureComponent = source.FurnitureComponents.Where(dm => dm.FurnitureId == order.FurnitureId);
                foreach (var dm in furnitureComponent)
                {
                    int componentCount = dm.Count * order.Count;
                    foreach (var sm in source.StorageComponents)
                    {
                        if (sm.ComponentId == dm.ComponentId && sm.Count >= componentCount)
                        {
                            sm.Count -= componentCount;
                            break;
                        }
                        else if (sm.MaterialId == dm.ComponentId && sm.Count < componentCount)
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
    }
}
