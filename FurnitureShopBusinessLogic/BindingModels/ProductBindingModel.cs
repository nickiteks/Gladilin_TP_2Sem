using FurnitureShopBusinessLogic.BindingModels;
using System.Collections.Generic;

namespace FurnitureShopBusinessLogic.Interfaces
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}