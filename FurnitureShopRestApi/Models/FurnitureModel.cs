﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureShopRestApi.Models
{
    public class FurnitureModel
    {
        public int Id { get; set; }

        public string FurnitureName { get; set; }

        public decimal Price { get; set; }
    }
}
