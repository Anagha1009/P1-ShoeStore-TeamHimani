using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesWeb.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int? Product_Id { get; set; }
        public decimal TotalBill { get; set; }
        public int? Customer_Id { get; set; }
        public int? Store_Id { get; set; }        
        public DateTime Date { get; set; }
        public int Order_IdF { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
    }
}