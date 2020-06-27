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
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FurnitureName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 80)]
        public decimal Sum { get; set; }
        [Column(title: "Исполнитель", width: 70)]
        public string ImplementerFIO { set; get; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
        public int? ImplementerId { set; get; }
        public override List<string> Properties() => new List<string> 
        { "Id", "ClientFIO", "FurnitureName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate", "DateImplement" };
    }
}

