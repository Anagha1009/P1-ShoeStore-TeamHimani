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
    public class OrderController : Controller
    {
        // GET: Order
        private OrderModel db;
        OrderRepository repo;
        public OrderController()
        {
            db = new OrderModel();
            repo = new OrderRepository(new OrderModel());
        }

        [HttpGet]
        public ActionResult PlaceOrder(Order order)
        {
            int cid = Convert.ToInt32(Session["Customer_id"]);
            repo.PlaceOrder(Mapper.MapOrder(order), Mapper.MapOrderDetails(order), cid);
            return RedirectToAction("ViewCart", "CartItem");
        }

        [HttpGet]
        public ActionResult Index()
        {
            int cid = Convert.ToInt32(Session["Customer_id"]);
            var result = repo.ViewOrder(cid);

            var data = new List<Order>();
            foreach (var p in result)
            {
                data.Add(Mapper.MapViewOrder(p));
            }

            return View(data);
        }
    }
}