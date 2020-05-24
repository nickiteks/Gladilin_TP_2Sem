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
        private readonly IFurnitureLogic furnitureLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IFurnitureLogic Logic, IOrderLogic orderLLogic)
        {
            this.furnitureLogic = Logic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportFurnitureComponentViewModel> GetFurnitureComponent()
        {
            var furnitures = furnitureLogic.Read(null);
            var list = new List<ReportFurnitureComponentViewModel>();
            foreach (var furnidure in furnitures)
            {
                foreach (var fb in furnidure.FurnitureComponents)
                {
                    var record = new ReportFurnitureComponentViewModel
                    {
                        FurnitureName = furnidure.FurnitureName,
                        ComponentName = fb.Value.Item1,
                        Count = fb.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
           .Read(new OrderBindingModel
           {
               DateFrom = model.DateFrom,
               DateTo = model.DateTo
           })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return list;
        }
        /// <summary>
        /// Сохранение изделий в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveFurnitureToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "The list of Furnitures",
                Furnitures = furnitureLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение изделий в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveFurnitureComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "The list of orders",
                Orders = GetOrders(model)
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveFurnituresToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "The list furniture with components",
                Furnitures = GetFurnitureComponent()
            });
        }
    }
}
