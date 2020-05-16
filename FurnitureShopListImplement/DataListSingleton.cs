using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopListImplement.Models
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<FurnitureComponent> FurnitureComponents { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageComponent> StorageComponents { get ; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Furnitures = new List<Furniture>();
            FurnitureComponents = new List<FurnitureComponent>();
            Storages = new List<Storage>();
            StorageComponents = new List<StorageComponent>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
