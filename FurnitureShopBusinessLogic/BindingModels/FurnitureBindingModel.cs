using FurnitureShopBusinessLogic.BindingModels;
using System.Collections.Generic;

namespace FurnitureShopBusinessLogic.Interfaces
{
    public class FurnitureBindingModel
    {
        public int? Id { get; set; }
        public string FurnitureName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FurnitureComponents { get; set; }
    }
}