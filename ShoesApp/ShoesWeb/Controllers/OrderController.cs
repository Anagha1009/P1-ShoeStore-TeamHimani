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
        private CartItemModel cm;
        OrderRepository repo;
        CartItemRepository repo1;
        public OrderController()
        {
            db = new OrderModel();
            cm = new CartItemModel();
            repo = new OrderRepository(new OrderModel());
            repo1 = new CartItemRepository(new CartItemModel());
        }

        [HttpGet]
        public ActionResult PlaceOrder(Order order)
        {
            int cid = Convert.ToInt32(Session["Customer_id"]);
            
            var d = cm.tb_cartitem.Where<tb_cartitem>(p => p.customer_id == cid).ToList();

            int nCount = 0;
            foreach(var t in d)
            {
                var check = repo.CheckInventory(t.product_id);

                if (!check)
                {
                    nCount++;
                }
            }

            if(nCount == 0)
            {
                repo.PlaceOrder(Mapper.MapOrder(order), Mapper.MapOrderDetails(order), cid);

                foreach (var v in d)
                {
                    repo.DeleteInventory(v.product_id);
                    repo1.DeleteCart(v.cart_id);
                }
                repo1.Save();
                repo.Save();

                return RedirectToAction("ViewCart", "CartItem");
            }
            else
            {
                //out of stock
            }

            return RedirectToAction("ViewCart", "CartItem");

            //repo.DeleteCart(cid);


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