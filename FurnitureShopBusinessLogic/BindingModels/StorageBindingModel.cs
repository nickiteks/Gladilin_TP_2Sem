using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int? Id { set; get; }
        public string StorageName { set; get; }
        public Dictionary<int, (string, int)> StoragedComponents { get; set; }
    }
}
