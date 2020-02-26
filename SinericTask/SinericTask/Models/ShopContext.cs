using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinericTask.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(string connectionSgting)
        {
            Database.Connection.ConnectionString = connectionSgting;
        }
        public DbSet<Shop> Shops { get; set; }

        //public ShopContext() : base("name = ShopContext") { }
        //public DbSet<Shop> Shops { get; set; }

    }

    
}