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
        public void CreateOrUpdate(StorageBindingModel model)
        {
            Storage tempStorage = model.Id.HasValue ? null : new Storage
            {
                Id = 1
            };
            foreach (var component in source.Storages)
            {
                if (!model.Id.HasValue && component.Id >= tempStorage.Id)
                {
                    tempStorage.Id = component.Id + 1;
                }
                else if (model.Id.HasValue && component.Id == model.Id)
                {
                    tempStorage = component;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempStorage == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempStorage);
            }
            else
            {
                source.Storages.Add(CreateModel(model, tempStorage));
            }
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            foreach (var component in source.Storages)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private Storage CreateModel(StorageBindingModel model, Storage storage)
        {
            storage.StorageName = model.StorageName;
            int maxSMId = 0;
            for (int i = 0; i < source.StorageComponents.Count; ++i)
            {
                if (source.StorageComponents[i].Id > maxSMId)
                {
                    maxSMId = source.StorageComponents[i].Id;
                }
                if (source.StorageComponents[i].StorageId == storage.Id)
                {
                    if (model.StoragedComponents.ContainsKey(source.StorageComponents[i].MaterialId))
                    {
                        source.StorageComponents[i].Count = model.StoragedComponents[source.StorageComponents[i].MaterialId].Item2;
                        model.StoragedComponents.Remove(source.StorageComponents[i].MaterialId);
                    }
                    else
                    {
                        source.StorageComponents.RemoveAt(i--);
                    }
                }
            }
            foreach (var sm in model.StoragedComponents)
            {
                source.StorageComponents.Add(new StorageComponent
                {
                    Id = ++maxSMId,
                    StorageId = storage.Id,
                    MaterialId = sm.Key,
                    Count = sm.Value.Item2
                });
            }
            return storage;
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
        private StorageViewModel CreateViewModel(Storage storage)
        {
            Dictionary<int, (string, int)> storageMaterials = new Dictionary<int, (string, int)>();
            foreach (var sm in source.StorageComponents)
            {
                if (sm.StorageId == storage.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (sm.MaterialId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    storageMaterials.Add(sm.MaterialId, (componentName, sm.Count));
                }
            }
            return new StorageViewModel
            {
                Id = storage.Id,
                StorageName = storage.StorageName,
                StoragedComponents = storageMaterials
            };
        }
    }
}
