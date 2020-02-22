using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Номер склада")]
        public string ComponentName { get; set; }
    }
}
