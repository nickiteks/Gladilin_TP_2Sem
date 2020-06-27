using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly IStorageLogic _storageLogic;

        public StorageController(IStorageLogic storageLogic)
        {
            _storageLogic = storageLogic;
        }

        [HttpGet]
        public List<StorageViewModel> GetStorages() => _storageLogic.Read(null);

        [HttpGet]
        public StorageViewModel GetStorage(int StorageId) => _storageLogic.Read(new StorageBindingModel
        {
            Id = StorageId
        }).FirstOrDefault();

        [HttpPost]
        public void CreateOrUpdateStorage(StorageBindingModel model) => _storageLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorage(StorageBindingModel model) => _storageLogic.Delete(model);

        [HttpPost]
        public void AddComponentOnStorage(StorageAddComponentBindingModel model) => _storageLogic.AddMaterialToStorage(model);
    }
}