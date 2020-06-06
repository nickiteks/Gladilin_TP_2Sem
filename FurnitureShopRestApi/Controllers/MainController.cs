using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.BusnessLogics;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using FurnitureShopRestApi.Models;
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
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IFurnitureLogic furniture, MainLogic main)
        {
            _order = order;
            _furniture = furniture;
            _main = main;
        }
        [HttpGet]
        public List<FurnitureModel> GetFurnitureList() => _furniture.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public FurnitureModel GetFurniture(int FurnitureId) => Convert(_furniture.Read(new FurnitureBindingModel
        {
            Id = FurnitureId
        })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        {
            ClientId = clientId
        });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private FurnitureModel Convert(FurnitureViewModel model)
        {
            if (model == null) return null;
            return new FurnitureModel
            {
                Id = model.Id,
                FurnitureName = model.FurnitureName,
                Price = model.Price
            };
        }
    }
}