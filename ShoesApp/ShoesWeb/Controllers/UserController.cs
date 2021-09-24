using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Entites;
using Data.Repository;
using Data;
using System.Web.Mvc;
using ShoesWeb.Models;

namespace ShoesWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private UserModel db;


        UserRepository repo;
        CartItemRepository repo1;
        public UserController()
        {
            db = new UserModel();
            repo = new UserRepository(new UserModel());
            repo1 = new CartItemRepository(new CartItemModel());
        }

        [HttpGet]
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(User user)
        {
            if (ModelState.IsValid)
            {
                repo.RegisterCustomer(Mapper.Mapuser(user), Mapper.Mapcust(user));
                return RedirectToAction("LoginCustomer","User");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult LoginCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCustomer(User user)
        {

            string username = repo.LoginCustomer(Mapper.Mapuser(user));
            if (!String.IsNullOrEmpty(username))
            {
                var u_id = db.tb_users.Where(e => e.username == username).FirstOrDefault().user_id;
                var role = db.tb_users.Where(e => e.username == username).FirstOrDefault().role;

                if (role.ToLower() == "customer")
                {
                    var custid = db.tb_customers.Where(e => e.user_id == u_id).FirstOrDefault().customer_id;

                    var cartitemscount = repo1.GetCartItemsCount(custid);

                    Session["Customer_id"] = custid;
                    Session["cartitem_count"] = cartitemscount;
                    // TempData["Customer_id"] = custid;
                }
                Session["username"] = username;
                Session["role"] = role;
                //TempData["username"] = username;
                //TempData.Keep();
                //var user1 = username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "<script type='text/javascript'>$(document).ready(function () {swal({title: 'Failed!',text: 'Your Username and/or Password is incorrect. Please try again!',type: 'error'})});</script>";

            }

            return View(user);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginCustomer", "User");
        }


        //nikita
        public ActionResult GetCustomer(string name)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                var data1 = repo.GetCustomer();
                var data = new List<User>();
                foreach (var p in data1)
                {
                    data.Add(Mapper.MapCustomer(p));

                }
                if (name != null)
                {
                    data = data.Where(x => x.Customer_Name.Contains(name)).ToList();
                }
                //var data = repo.GetCustomerByName(name);
                return View(data);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            

        }
    }
}