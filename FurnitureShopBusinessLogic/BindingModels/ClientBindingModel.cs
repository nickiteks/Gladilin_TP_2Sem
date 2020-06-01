using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopBusinessLogic.BindingModels
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }
        public string ClientFio { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
