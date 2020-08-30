using FurnitureShopDataBaseImpliment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopDataBaseImpliment
{
    public class FurnitureShopDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-46FCCKM\SQLEXPRESS;
                Initial Catalog=Lab6FurnitureShopStorageDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Furniture> Furnitures { set; get; }
        public virtual DbSet<FurnitureComponent> FurnitureComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Storage> Storages { set; get; }
        public virtual DbSet<StorageComponent> StorageComponents { set; get; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Implementer> Implementers { get; set; }
    }
}
