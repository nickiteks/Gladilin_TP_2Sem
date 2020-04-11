using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopFileImplement.Implements
{
    public class FurnitureLogic : IFurnitureLogic
    {
        private readonly FileDataListSingleton source;
        public FurnitureLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(FurnitureBindingModel model)
        {
            Furniture element = source.Furnitures.FirstOrDefault(rec => rec.FurnitureName ==
           model.FurnitureName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Furnitures.Count > 0 ? source.Components.Max(rec =>
               rec.Id) : 0;
                element = new Furniture { Id = maxId + 1 };
                source.Furnitures.Add(element);
            }
            element.FurnitureName = model.FurnitureName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.FurnitureComponents.RemoveAll(rec => rec.FurnitureId == model.Id &&
           !model.FurnitureComponents.ContainsKey(rec.ComponentId));
            // обновили количество у существующих записей
            var updateComponents = source.FurnitureComponents.Where(rec => rec.FurnitureId ==
           model.Id && model.FurnitureComponents.ContainsKey(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count =
               model.FurnitureComponents[updateComponent.ComponentId].Item2;
                model.FurnitureComponents.Remove(updateComponent.ComponentId);
            }
            // добавили новые
            int maxPCId = source.FurnitureComponents.Count > 0 ?
           source.FurnitureComponents.Max(rec => rec.Id) : 0;
        foreach (var pc in model.FurnitureComponents)
            {
                source.FurnitureComponents.Add(new FurnitureComponent
                {
                    Id = ++maxPCId,
                    FurnitureId = element.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(FurnitureBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.FurnitureComponents.RemoveAll(rec => rec.FurnitureId == model.Id);
            Furniture element = source.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Furnitures.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<FurnitureViewModel> Read(FurnitureBindingModel model)
        {
            return source.Furnitures
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new FurnitureViewModel
            {
                Id = rec.Id,
                FurnitureName = rec.FurnitureName,
                Price = rec.Price,
                FurnitureComponents = source.FurnitureComponents
            .Where(recPC => recPC.FurnitureId == rec.Id)
           .ToDictionary(recPC => recPC.ComponentId, recPC =>
            (source.Components.FirstOrDefault(recC => recC.Id ==
           recPC.ComponentId)?.ComponentName, recPC.Count))
            })
            .ToList();
        }
    }
}
