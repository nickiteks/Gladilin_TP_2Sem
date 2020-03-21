﻿using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace FurnitureShopListImplement.Implements
{
    public class FurnitureLogic : IFurnitureLogic
    {
        private readonly DataListSingleton source;
        public FurnitureLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(FurnitureBindingModel model)
        {
            Furniture tempProduct = model.Id.HasValue ? null : new Furniture { Id = 1 };
            foreach (var product in source.Products)
            {
                if (product.FurnitureName == model.FurnitureName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
            if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Products.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(FurnitureBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].FurnitureId == model.Id)
                {
                    source.ProductComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Furniture CreateModel(FurnitureBindingModel model, Furniture product)
        {
            product.FurnitureName = model.FurnitureName;
            product.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].Id;
                }
                if (source.ProductComponents[i].FurnitureId == product.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.FurnitureComponents.ContainsKey(source.ProductComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.ProductComponents[i].Count =
                        model.FurnitureComponents[source.ProductComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не
                    
model.FurnitureComponents.Remove(source.ProductComponents[i].ComponentId);
                    }
                    else
                    {
                        source.ProductComponents.RemoveAt(i--);
                     }
                }
            }
            // новые записи
            foreach (var pc in model.FurnitureComponents)
            {
                source.ProductComponents.Add(new FurnitureComponent
                {
                    Id = ++maxPCId,
                    FurnitureId = product.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<FurnitureViewModel> Read(FurnitureBindingModel model)
        {
            List<FurnitureViewModel> result = new List<FurnitureViewModel>();
            foreach (var component in source.Products)
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
        private FurnitureViewModel CreateViewModel(Furniture product)
        {
            // требуется дополнительно получить список компонентов для изделия с
        Dictionary<int, (string, int)> productComponents = new Dictionary<int,
(string, int)>();
            foreach (var pc in source.ProductComponents)
            {
                if (pc.FurnitureId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (pc.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    productComponents.Add(pc.ComponentId, (componentName, pc.Count));
                }
            }
            return new FurnitureViewModel
            {
                Id = product.Id,
            FurnitureName = product.FurnitureName,
                Price = product.Price,
                FurnitureComponents = productComponents
            };
        }
    }
}