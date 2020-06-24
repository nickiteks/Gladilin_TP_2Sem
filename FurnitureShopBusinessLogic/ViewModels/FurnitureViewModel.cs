using FurnitureShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    public class FurnitureViewModel : BaseViewModel
    {
        [Column(title: "Название мебели", width: 150)]
        public string FurnitureName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FurnitureComponents { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "FurnitureName", "Price" };
    }
}
