using FurnitureShopBusinessLogic.Enums;
using FurnitureShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FurnitureShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string FurnitureFileName = "Furniture.xml";
        private readonly string FurnitureComponentFileName = "FurnitureComponent.xml";

        private readonly string StorageFileName = "Storage.xml";
        private readonly string StorageComponentFileName = "StorageComponent.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<FurnitureComponent> FurnitureComponents { get; set; }
        public List<Storage> Storages { set; get; }
        public List<StorageComponent> StorageComponents { set; get; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Furnitures = LoadProducts();
            FurnitureComponents = LoadProductComponents();
            Storages = LoadStorages();
            StorageComponents = LoadStorageMaterials();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveProducts();
            SaveProductComponents();
            SaveStorageMaterials();
            SaveStorages();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                if (xElements != null)
                {
                    foreach (var elem in xElements)
                    {
                        list.Add(new Order
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            FurnitureId = Convert.ToInt32(elem.Element("FurnitureId").Value),
                            Count = Convert.ToInt32(elem.Element("Count").Value),
                            Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                            DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                            DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                        });
                    }
                }
            }
            return list;
        }
        private List<Furniture> LoadProducts()
        {
            var list = new List<Furniture>();
            if (File.Exists(FurnitureFileName))
            {
                XDocument xDocument = XDocument.Load(FurnitureFileName);
                var xElements = xDocument.Root.Elements("Furniture").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Furniture
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureName = elem.Element("FurnitureName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }

        private List<FurnitureComponent> LoadProductComponents()
        {
            var list = new List<FurnitureComponent>();
            if (File.Exists(FurnitureComponentFileName))
            {
                XDocument xDocument = XDocument.Load(FurnitureComponentFileName);
                var xElements = xDocument.Root.Elements("FurnitureComponent").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new FurnitureComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureId = Convert.ToInt32(elem.Element("FurnitureId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }

        private List<Storage> LoadStorages()
        {
            var list = new List<Storage>();
            if (File.Exists(StorageFileName))
            {
                XDocument xDocument = XDocument.Load(StorageFileName);
                var xElements = xDocument.Root.Elements("Storage").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Storage()
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StorageName = elem.Element("StorageName").Value.ToString()
                    });
                }
            }
            return list;
        }

        private List<StorageComponent> LoadStorageMaterials()
        {
            var list = new List<StorageComponent>();
            if (File.Exists(StorageComponentFileName))
            {
                XDocument xDocument = XDocument.Load(StorageComponentFileName);
                var xElements = xDocument.Root.Elements("StorageMaterial").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new StorageComponent()
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        StorageId = Convert.ToInt32(elem.Element("StorageId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),

                    new XElement("FurnitureId", order.FurnitureId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveProducts()
        {
            if (Furnitures != null)
            {
                var xElement = new XElement("Furnitures");
                foreach (var product in Furnitures)
                {
                    xElement.Add(new XElement("Furniture",
                    new XAttribute("Id", product.Id),
                    new XElement("FurnitureName", product.FurnitureName),
                    new XElement("Price", product.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FurnitureFileName);
            }
        }
        private void SaveProductComponents()
        {
            if (FurnitureComponents != null)
            {

                var xElement = new XElement("FurnitureComponents");
                foreach (var productComponent in FurnitureComponents)
                {
                    xElement.Add(new XElement("FurnitureComponent",
                    new XAttribute("Id", productComponent.Id),
                    new XElement("FurnitureId", productComponent.FurnitureId),
                    new XElement("ComponentId", productComponent.ComponentId),
                    new XElement("Count", productComponent.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FurnitureComponentFileName);
            }
        }

        private void SaveStorages()
        {
            if (Storages != null)
            {
                var xElement = new XElement("Storages");
                foreach (var elem in Storages)
                {
                    xElement.Add(new XElement("Storage",
                        new XAttribute("Id", elem.Id),
                        new XElement("StorageName", elem.StorageName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StorageFileName);
            }
        }

        private void SaveStorageMaterials()
        {
            if (StorageComponents != null)
            {
                var xElement = new XElement("StorageComponents");
                foreach (var elem in StorageComponents)
                {
                    xElement.Add(new XElement("StorageComponent",
                        new XAttribute("Id", elem.Id),
                        new XElement("ComponentId", elem.ComponentId),
                        new XElement("StorageId", elem.StorageId),
                        new XElement("Count", elem.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StorageComponentFileName);
            }
        }
    }
}
