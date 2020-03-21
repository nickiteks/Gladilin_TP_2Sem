﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { set; get; }
        [DisplayName("Хранилище")]
        public string StorageName { set; get; }
        public Dictionary<int, (string, int)> StoragedComponents { get; set; }
    }
}
