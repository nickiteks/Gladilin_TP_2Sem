using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopListImplement.Models
{
    public class StorageComponent
    {
        public int Id { set; get; }
        public int StorageId { set; get; }
        public int ComponentId { set; get; }
        public int Count { set; get; }
    }
}
