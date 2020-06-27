using FurnitureShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FurnitureShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        public int FurnitureId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Furniture Furnitures { get; set; }
        public int? ImplementerId { set; get; }
        public string ImplementerFIO { set; get; }
        public virtual Client Client { set; get; }
        public virtual Implementer Implementer { set; get; }

    }
}
