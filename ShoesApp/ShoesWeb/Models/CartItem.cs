using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Entites;

namespace ShoesWeb.Models
{
    public class CartItem
    {
        public int Cart_Id { get; set; }

        public int? Customer_Id { get; set; }

        public int? Store_Id { get; set; }
        public int Product_Id { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
    }
}