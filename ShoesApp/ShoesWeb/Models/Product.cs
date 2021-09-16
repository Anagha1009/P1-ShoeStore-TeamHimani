using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoesWeb.Models
{
    public class Product
    {
        [DisplayName("Id")]
        public int Product_Id { get; set; }
        [DisplayName("Name")]
        public string Product_Name { get; set; }       
        public int? Category_Id { get; set; } 
        public string Category_Name { get; set; }
        public int? Store_Id { get; set; }
        public string Store_Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        
        
    }
    
}