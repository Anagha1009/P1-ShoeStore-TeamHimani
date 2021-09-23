using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Entites;
using Data;
using Data.Repository;
using ShoesWeb.Models;

namespace ShoesWeb.Controllers
{
    public class CartController : Controller
    {

        ProductRepository repo;
        CartRepository repo1;
        public CartController()
        {
            repo = new ProductRepository(new ProductModel());
            repo1 = new CartRepository(new CartModel());
        }
        // GET: Cart

        [HttpGet]
        public ActionResult Index()
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                var product = repo.GetProducts();

                var data = new List<Product>();
                foreach (var p in product)
                {
                    data.Add(Mapper.Map(p));

                }
                return View(data);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
        }
        [HttpGet]
        public ActionResult AddCart(Cart cart, int? id)
        {
            int cid = Convert.ToInt32(Session["Customer_id"]);
            repo1.AddCartItems(Mapper.Mapcart(cart), Mapper.Mapcartdetails(cart), id, cid);
            return RedirectToAction("Index", "Cart");
        }
    }
}