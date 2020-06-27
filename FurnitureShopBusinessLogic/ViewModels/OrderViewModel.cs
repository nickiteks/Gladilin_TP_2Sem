using FurnitureShopBusinessLogic.Attributes;
using FurnitureShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        public int FurnitureId { get; set; }
        [DisplayName("Клиент")]
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [DisplayName("Изделие")]
        [Column(title: "Изделие", width: 100)]
        [DataMember]
        public string FurnitureName { get; set; }
        [DisplayName("Количество")]
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        [Column(title: "Сумма", width: 80)]
        [DataMember]
        public decimal Sum { get; set; }
        [DisplayName("Исполнитель")]
        [Column(title: "Исполнитель", width: 70)]
        [DataMember]
        public string ImplementerFIO { set; get; }
        [DisplayName("Статус")]
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        [Column(title: "Дата создания", width: 120)]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        [Column(title: "Дата выполнения", width: 120)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
        public int? ImplementerId { set; get; }
        public override List<string> Properties() => new List<string> { "Id",
        "ClientFIO", "FurnitureName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate",
        "DateImplement" };
    }
}
