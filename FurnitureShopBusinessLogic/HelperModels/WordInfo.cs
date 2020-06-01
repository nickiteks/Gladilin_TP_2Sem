using System;
using System.Collections.Generic;
using System.Text;
using FurnitureShopBusinessLogic.ViewModels;

namespace FurnitureShopBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<FurnitureViewModel> furnitures { get; set; }
    }
}
