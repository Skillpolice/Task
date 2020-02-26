using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightPointTask.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TimeWork { get; set; } 
        public int? GoodsId { get; set; }
        
    }
    public class Goods
    {
        public int ShopId { get; set; }
        public int Id { get; set; }
        public string NameGoods { get; set; }
        public string Description { get; set; }
       
    }


}