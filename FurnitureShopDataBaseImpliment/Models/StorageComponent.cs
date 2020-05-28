using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FurnitureShopDataBaseImpliment.Models
{
    public class StorageComponent
    {
        public int Id { set; get; }
        public int StorageId { set; get; }
        public int ComponentId { set; get; }
        [Required]
        public int Count { set; get; }
        public virtual Storage Storage { set; get; }
        public virtual Component Component { set; get; }
    }
}
