using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.BusnessLogics;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IOrderLogic _order;
        private readonly IFurnitureLogic _furniture;
        private readonly IComponentLogic _componentLogic;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IFurnitureLogic Furniture, MainLogic main, IComponentLogic componentLogic)
        {
            _order = order;
            _furniture = Furniture;
            _main = main;
            _componentLogic = componentLogic;
        }

        [HttpGet]
        public List<FurnitureViewModel> GetFurnitureList() => _furniture.Read(null);

        [HttpGet]
        public List<ComponentViewModel> GetComponentList() => _componentLogic.Read(null);

        [HttpGet]
        public FurnitureViewModel GetFurniture(int furnitureId) => _furniture.Read(new FurnitureBindingModel
        {
            Id = furnitureId
        })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        {
            ClientId = clientId
        });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}