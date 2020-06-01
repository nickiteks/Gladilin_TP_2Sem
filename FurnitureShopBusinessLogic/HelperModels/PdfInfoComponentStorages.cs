using System;
using System.Collections.Generic;
using System.Text;
using FurnitureShopBusinessLogic.ViewModels;

namespace FurnitureShopBusinessLogic.HelperModels
{
    public class PdfInfoComponentStorages
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportStorageComponent> ComponentStorages { get; set; }
    }
}
