using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.BindingModels
{
    public class StorageAddComponentsBindingModel
    {
        public int StorageId { set; get; }
        public int ComponentId { set; get; }
        public int ComponentCount { set; get; }
    }
}
