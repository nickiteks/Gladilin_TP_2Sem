using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.HelperModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureShopBusinessLogic.BusnessLogics
{
    public class ReportLogic
    {
        private readonly IComponentLogic componentLogic;
        private readonly IFurnitureLogic furnitureLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;

        public ReportLogic(IFurnitureLogic productLogic, IComponentLogic componentLogic,
            IOrderLogic orderLLogic, IStorageLogic storageLogic)
        {
            this.furnitureLogic = productLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
            this.storageLogic = storageLogic;
        }

        public List<ReportFurnitureComponentViewModel> GetFurnitureComponents()
        {
            var components = componentLogic.Read(null);
            var furniture = furnitureLogic.Read(null);
            var list = new List<ReportFurnitureComponentViewModel>();
            foreach (var component in components)
            {
                foreach (var furnitures in furniture)
                {
                    if (furnitures.FurnitureComponents.ContainsKey(component.Id))
                    {
                        var record = new ReportFurnitureComponentViewModel
                        {
                            FurnitureName = furnitures.FurnitureName,
                            ComponentName = component.ComponentName,
                            ComponentCount = furnitures.FurnitureComponents[component.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        // Получение списка заказов за определенный период
        public List<IGrouping<DateTime, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FurnitureName = x.FurnitureName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .GroupBy(x => x.DateCreate)
           .ToList();
        }

        public List<ReportOrdersViewModel> GetOrders()
        {
            return orderLogic.Read(null)
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FurnitureName = x.FurnitureName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        public List<ReportStorageViewModel> GetStorages()
        {
            return storageLogic.Read(null).Select(s => new ReportStorageViewModel()
            {
                StorageName = s.StorageName,
                Components = s.StoragedComponents
            }).ToList();
        }

        public List<ReportStorageComponent> GetComponentsStorages()
        {
            var storages = storageLogic.Read(null);
            List<ReportStorageComponent> reportComponentStorages = new List<ReportStorageComponent>();
            foreach (var storage in storages)
            {
                foreach (var component in storage.StoragedComponents)
                {
                    reportComponentStorages.Add(new ReportStorageComponent()
                    {
                        StorageName = storage.StorageName,
                        ComponentName = component.Key,
                        ComponentCount = component.Value
                    });
                }
            }
            return reportComponentStorages;
        }

        // Сохранение компонент в файл-Word
        public void SaveFurnitureesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Мебель",
                furnitures = furnitureLogic.Read(null)
            });
        }

        public void SaveStoragesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfoStorages
            {
                FileName = model.FileName,
                Title = "Хранилища",
                Storages = storageLogic.Read(null)
            });
        }

        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveProductComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Заказы",
                Orders = GetOrders()
            });
        }

        public void SaveStoragesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfoStorages
            {
                FileName = model.FileName,
                Title = "Склады",
                Storages = GetStorages()
            });
        }

        [Obsolete]
        public void SaveFurnituresComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Мебель",
                furnitures = GetFurnitureComponents()
            });
        }

        [Obsolete]
        public void SaveComponentsStoragesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfoComponentStorages
            {
                FileName = model.FileName,
                Title = "Компоненты на складах",
                ComponentStorages = GetComponentsStorages()
            });
        }
    }
}
