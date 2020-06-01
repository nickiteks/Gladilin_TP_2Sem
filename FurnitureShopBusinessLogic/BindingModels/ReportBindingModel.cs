using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic
{
    public class ReportBindingModel
    {
        public string FileName { set; get; }
        public DateTime? DateFrom { set; get; }
        public DateTime? DateTo { set; get; }
    }
}
