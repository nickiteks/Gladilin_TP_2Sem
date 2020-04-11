using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.ViewModels;
using System.Collections.Generic;


namespace FurnitureShopBusinessLogic.Interfaces
{
    public interface IFurnitureLogic
    {
        List<FurnitureViewModel> Read(FurnitureBindingModel model);
        void CreateOrUpdate(FurnitureBindingModel model);
        void Delete(FurnitureBindingModel model);
    }
}
