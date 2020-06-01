using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    public class ReportStorageViewModel
    {
        public string StorageName { set; get; }
        public Dictionary<string, int> Components { set; get; }
    }
}
