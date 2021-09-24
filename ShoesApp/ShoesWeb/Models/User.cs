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
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public int Customer_Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Customer_Name { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        //[RegularExpression(@"/ ^([\w -\.] +)@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{ 1,3}\.)| (([\w -] +\.)+))([a - zA - Z]{ 2,4}|[0 - 9]{ 1,3})(\]?)$/",
        //                    ErrorMessage = "Please enter a valid email address")]
       
        public string Customer_Email { get; set; }

        [Required(ErrorMessage = "Please enter Contact")]

        [StringLength(10, ErrorMessage = "Contact No. must contains 10 characters", MinimumLength = 10)]
        public string Customer_Contact { get; set; }

        

    }
    

}