using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesWeb.Models
{
    public class Cart
    {
        public int Cart_Id { get; set; }
        public int Product_Id { get; set; }
        public  decimal TotalBill { get; set; }
        public int Customer_Id { get; set; }
        public int Store_Id { get; set; }
        public int Quantity { get; set; }

    }
    public class ViewCart
    {
        public int Cart_Id { get; set; }
        public int Product_Id { get; set; }
        public decimal TotalBill { get; set; }
        public int Customer_Id { get; set; }
        public int Store_Id { get; set; }
        public int Quantity { get; set; }

        public string Product_Name { get; set; }

        public string Product_Image { get; set; }
        public int Product_Quantity{ get; set; }
        public decimal Product_Price { get; set; }

    }

}