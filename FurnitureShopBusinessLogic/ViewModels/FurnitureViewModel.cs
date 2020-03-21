using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    public class FurnitureViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string FurnitureName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FurnitureComponents { get; set; }
    }
}
