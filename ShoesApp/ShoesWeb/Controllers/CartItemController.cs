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
        Data.ProductRepository repo1;
        public CartItemController()
        {
            db = new CartItemModel();
            repo = new CartItemRepository(new CartItemModel());
            repo1 = new Data.ProductRepository(new ProductModel());
        }

        [HttpGet]
        public ActionResult AddCart(CartItem cart,int? pid,int? Color,int? Size)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                bool checkcolor = repo1.CheckColorAvailability(Color, pid);
                bool checksize = repo1.CheckSizeAvailability(Size, pid);

                if (checkcolor)
                {
                    if (checksize)
                    {
                        int cid = Convert.ToInt32(Session["Customer_id"]);
                        int? storeid = repo.AddCartItems(Mapper.MapCartItem(cart), pid, cid, Color, Size);
                        Session["cartitem_count"] = Convert.ToInt32(Session["cartitem_count"]) + 1;
                        return RedirectToAction("GetProducts", "Product", new { id = storeid });
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Sorry!This size is not available for this product'); window.location = '/Product/GetProducts';</script>");
                    }
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Sorry!This color is not available for this product'); window.location = '/Product/GetProducts';</script>");
                }
                
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

                Session["cartitem_count"] = Convert.ToInt32(Session["cartitem_count"]) - 1;
                return RedirectToAction("ViewCart", "CartItem");
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }           

        }
    }
}