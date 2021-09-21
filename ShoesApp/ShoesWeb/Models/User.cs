using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoesWeb.Models
{
    public class User
    {
        public int User_Id { get; set; }

        [Required(ErrorMessage = "Please enter Username")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        public string Role { get; set; }
        public int Customer_Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Customer_Name { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        public string Customer_Email { get; set; }

        [Required(ErrorMessage = "Please enter Contact")]
        public string Customer_Contact { get; set; }

    }
   
}