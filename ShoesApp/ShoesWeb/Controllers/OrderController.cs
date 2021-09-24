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
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
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
                        Session["cartitem_count"] = Convert.ToInt32(Session["cartitem_count"]) - 1;
                    }
                    repo1.Save();
                    repo.Save();
                    
                    return RedirectToAction("ShowMessage", "Order");
                }
                else
                {
                    //out of stock
                }

                return RedirectToAction("ViewCart", "CartItem");
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            

            //repo.DeleteCart(cid);
        }

        public ActionResult ShowMessage()
        {
            ViewBag.Message = "<script type='text/javascript'>$(document).ready(function (){swal({text: 'You have successfully placed your order!',type: 'success',allowOutsideClick: false}).then(function() {window.location = '/Order/Index';})});</script>";

            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
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
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }

        [HttpGet]
        public ActionResult AllOrder(int? id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                ViewBag.Store = new SelectList(repo.getStore(), "store_id", "store_name");
                var data1 = repo.GetOrder();
                var data = new List<Order>();
                foreach (var p in data1)
                {
                    data.Add(Mapper.MapViewOrder(p));

                }
                if (id==null)
                {
                    
                }
                else
                {
                    data = data.Where(x => x.Store_Id==id).ToList();
                }
                //var data = repo.Or(id);
                //return View(data);
                //int cid = Convert.ToInt32(Session["Customer_id"]);
                //var result = repo.ViewOrder(cid);

                //var data = new List<Order>();
                //foreach (var p in result)
                //{
                //    data.Add(Mapper.MapViewOrder(p));
                //}

                //return View(data);
                return View(data);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }

        }
    }
}