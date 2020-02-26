using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LightPointTask.Models
{
    public class ShopContext:DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Goods> Goodss { get; set; }
    }

    public class ShopDbInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            db.Shops.Add(new Shop { Name = "Adidas ", Adress = " Pyshkina ", TimeWork = " 9-21:00" ,GoodsId=1});
            db.Shops.Add(new Shop { Name = "Sosedi ", Adress = " Pyshkina ", TimeWork = " 24/7" ,GoodsId=2});
            db.Goodss.Add(new Goods { ShopId = 1,NameGoods = "Langs", Description = "langs",});
            db.Goodss.Add(new Goods { ShopId = 2, NameGoods = "milk", Description = "Made in Belarus", });
            db.Goodss.Add(new Goods { ShopId = 1, NameGoods = "head", Description = "Head", });    
            
            db.Goodss.Add(new Goods { ShopId = 2, NameGoods = "Колбоса", Description = "из говдины",});
;
            base.Seed(db);
        }
    }
}