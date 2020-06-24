﻿using FurnitureShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "ФИО", width: 100)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Логин", width: 100)]
        public string Email { get; set; }
        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "ClientFIO", "Email", "Password" };
    }
}
