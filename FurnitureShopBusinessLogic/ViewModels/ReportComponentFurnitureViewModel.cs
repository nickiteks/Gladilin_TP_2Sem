using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    public class ReportComponentFurnitureViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Furnitures { get; set; }
    }
}
