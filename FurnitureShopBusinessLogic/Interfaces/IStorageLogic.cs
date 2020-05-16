using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.Interfaces
{
    public interface IStorageLogic
    {
        List<StorageViewModel> Read(StorageBindingModel model);
        void CreateOrUpdate(StorageBindingModel model);
        void Delete(StorageBindingModel model);
        void AddComponentToStorage(StorageAddComponentsBindingModel model);
    }
}
