using FurnitureShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    [DataContract]
    public class FurnitureViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Изделие", width: 100)]
        public string FurnitureName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> FurnitureComponents { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "FurnitureName", "Price" };
    }
}
