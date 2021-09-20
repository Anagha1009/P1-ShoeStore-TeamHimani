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
        //// GET: Cart
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Index()
        {

            //repo.GetProducts();
            //return View();
            var product = repo.GetProducts();

            var data = new List<Product>();
            foreach (var p in product)
            {
                data.Add(Mapper.Map(p));

            }
            return View(data);
        }
        [HttpGet]
        public ActionResult AddCart(Cart cart,int? id,string cid)
        {
            //CartController ccc=new CartController();
            //HttpRequestBase req = ccc.HttpContext.Request;
            //int customer =Convert.ToInt32(req.Form.Get("lb_customerid"));
            int c_id = Convert.ToInt32(cid);
            
           
            repo1.AddCartItems(Mapper.Mapcart(cart), Mapper.Mapcartdetails(cart),id,c_id);
                return View(cart);

            
        }
        //[HttpPost]
        //public ActionResult AddCart(Cart cart)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        repo1.AddCartItems(Mapper.Mapcart(cart),Mapper.Mapcartdetails(cart));
        //        return RedirectToAction("Index");
        //    }
        //    return View(cart);
        //}

    }
}