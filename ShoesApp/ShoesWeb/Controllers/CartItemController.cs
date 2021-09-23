using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repository;
using Data.Entites;
using ShoesWeb.Models;
using System.IO;
using System.Net;

namespace ShoesWeb.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItem
        private CartItemModel db;
        CartItemRepository repo;
        public CartItemController()
        {
            db = new CartItemModel();
            repo = new CartItemRepository(new CartItemModel());
        }

        [HttpGet]
        public ActionResult AddCart(CartItem cart,int? pid,int? Color,int? Size)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                
                int cid = Convert.ToInt32(Session["Customer_id"]);
                int? storeid=repo.AddCartItems(Mapper.MapCartItem(cart), pid, cid,Color,Size);
                return RedirectToAction("GetProducts", "Product", new { id=storeid });

            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
     
        }

        [HttpGet]
        public ActionResult ViewCart()
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                int cid = Convert.ToInt32(Session["Customer_id"]);
                var result = repo.ViewCartItems(cid);           
           
                var data = new List<CartItem>();
            
                foreach (var p in result)
                {
                    data.Add(Mapper.MapViewCart(p));
                }

                return View(data);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }

        [HttpGet]
        public ActionResult DeleteCartById(int id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                repo.DeleteCart(id);
                repo.Save();
                return RedirectToAction("ViewCart", "CartItem");

            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            

        }
    }
}