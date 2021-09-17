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
        [Required(ErrorMessage = "Please enter first name")]
        public string Product_Name { get; set; }       
        public int? Category_Id { get; set; } 
        public string Category_Name { get; set; }
        public int? Store_Id { get; set; }
        public string Store_Name { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Color_Id { get; set; }
        public string Color { get; set; }
        public int Size_Id { get; set; }
        public decimal Size { get; set; }


    }
    
}