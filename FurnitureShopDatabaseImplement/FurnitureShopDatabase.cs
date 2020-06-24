using Microsoft.EntityFrameworkCore;
using FurnitureShopDatabaseImplement.Models; 
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopDatabaseImplement
{
    public class FurnitureShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (optionsBuilder.IsConfigured == false) 
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-46FCCKM\SQLEXPRESS;Initial Catalog=FurnitureShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            } 
            base.OnConfiguring(optionsBuilder); 
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Furniture> Furnitures { set; get; }
        public virtual DbSet<FurnitureComponent> FurnitureComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}
