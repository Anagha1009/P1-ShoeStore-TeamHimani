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
        [Required(ErrorMessage = "Please enter Product Name")]
        public string Product_Name { get; set; }        
        public int? Category_Id { get; set; }

        public string Category_Name { get; set; }        
        public int? Store_Id { get; set; }

        [Required(ErrorMessage = "Please select Store")]
        public string Store_Name { get; set; }

        [Required(ErrorMessage = "Please enter Product Price")]
        public decimal Product_Price { get; set; }

        [Required(ErrorMessage = "Please enter Product Quantity")]
        public int Product_Quantity { get; set; }        

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Product_Image { get; set; }
        public int? Color_Id { get; set; }
        public string Color { get; set; }
        public int? Size_Id { get; set; }
        public decimal Size { get; set; }
        public List<int> ColorList { set; get; }
    }
    
}