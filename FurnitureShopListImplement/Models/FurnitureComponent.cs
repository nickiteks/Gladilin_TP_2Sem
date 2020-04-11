using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopListImplement.Models
{
    public class FurnitureComponent
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
