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

        private readonly IFurnitureLogic productLogic;

        private readonly IOrderLogic orderLogic;
        public ReportLogic(IFurnitureLogic productLogic, IComponentLogic componentLogic, IOrderLogic orderLLogic) 
        { 
            this.productLogic = productLogic; 
            this.componentLogic = componentLogic; 
            this.orderLogic = orderLLogic; 
        }
         public List<ReportFurnitureOrdersViewModel> GetFurnitureComponent()
        {
            var components = componentLogic.Read(null);
            var furnitures = productLogic.Read(null);
            var list = new List<ReportFurnitureOrdersViewModel>();
            foreach (var component in components)
            {
                foreach (var furniture in furnitures)
                {
                    if (furniture.FurnitureComponents.ContainsKey(component.Id))
                    {
                        var record = new ReportFurnitureOrdersViewModel
                        {
                            FurnitureName = furniture.FurnitureName,
                            ComponentName = component.ComponentName,
                            Count = furniture.FurnitureComponents[component.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
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
           .ToList();
        }
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            { FileName = model.FileName,               
                Title = "Изделия",              
                Furnitures = productLogic.Read(null)     
            });
        }
        public void SaveProductComponentToExcelFile(ReportBindingModel model) 
        { SaveToExcel.CreateDoc(new ExcelInfo 
            {
               DateFrom = model.DateFrom.Value,
               DateTo = model.DateTo.Value,
               FileName = model.FileName,
               Title = "The list of orders",
               Orders = GetOrders(model)
            });
        }

        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model) 
        { 
            SaveToPdf.CreateDoc(new PdfInfo 
            {
                FileName = model.FileName,
                Title = "The list furnitures",
                Furnitures = GetFurnitureComponent()
            }); 
        }
    }
}
