using System;
using System.Collections.Generic;
using FurnitureShopBusinessLogic.ViewModels;
using System.Text;
using System.Linq;

namespace FurnitureShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportFurnitureOrdersViewModel> Furnitures { get; set; }
        public List<IGrouping<DateTime, OrderViewModel>> Orders { get; set; }
    }
}
