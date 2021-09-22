using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repository;
using Data.Entites;
using ShoesWeb.Models;

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
        public ActionResult AddCart(CartItem cart,int? id)
        {
            int cid = Convert.ToInt32(Session["Customer_id"]);
            repo.AddCartItems(Mapper.MapCartItem(cart), id, cid);
            return RedirectToAction("GetProducts", "Product");
        }

        [HttpGet]
        public ActionResult ViewCart()
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
    }
}