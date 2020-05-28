using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FurnitureShopDataBaseImpliment.Models
{
    public class FurnitureComponent
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Furniture Furniture { get; set; }
        public virtual Component Component { get; set; }
    }
}
