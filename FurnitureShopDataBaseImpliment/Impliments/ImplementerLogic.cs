﻿using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopDataBaseImpliment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopDataBaseImpliment.Impliments
{
    public class ImplementerLogic : IImplementerLogic
    {
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                Implementer element;
                if (model.Id.HasValue)
                {
                    element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Implementer();
                    context.Implementers.Add(element);
                }
                element.ImplementerFIO = model.ImplementerFIO;
                element.PauseTime = model.PauseTime;
                element.WorkingTime = model.WorkingTime;
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            using (var context = new FurnitureShopDataBase())
            {
                return context.Implementers
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    ImplementerFIO = rec.ImplementerFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }
    }
}
