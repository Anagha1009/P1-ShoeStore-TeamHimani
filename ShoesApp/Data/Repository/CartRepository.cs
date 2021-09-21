﻿using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private CartModel db;
        public CartRepository(CartModel db)
        {
            this.db = db;
        }
        ProductModel pm = new ProductModel();
        UserModel um = new UserModel();
        public void AddCartItems(tb_cart cart,tb_cartdetails cartdetails,int? id,int cid)
        {
            
            var cust = db.tb_cart.Where(e => e.customer_id == cid).FirstOrDefault();
            if (cust == null)
            {
                cart.customer_id = cid;
                cart.store_id = pm.tb_products.Where(e => e.product_id == id).FirstOrDefault().store_id;
                cart.total_bill = pm.tb_products.Where(e => e.product_id == id).FirstOrDefault().product_price;
                db.tb_cart.Add(cart);
                Save();
                cartdetails.cart_id = db.tb_cart.Max(c => c.cart_id);
            }
            else
            {
                //var pro = db.tb_cart.Find(id);
                var existingp = db.tb_cart.Where(e => e.customer_id == cid).FirstOrDefault();
                decimal newp = pm.tb_products.Where(e => e.product_id == id).FirstOrDefault().product_price;
                existingp.total_bill = existingp.total_bill + newp;
                Save();
                cartdetails.cart_id = db.tb_cart.Where(e => e.customer_id == cid).FirstOrDefault().cart_id;
            }

            cartdetails.product_id = id;
            cartdetails.quantity = 1;
            db.tb_cartdetails.Add(cartdetails);
            Save();
            //throw new NotImplementedException();
        }

        public void DeleteCartItems(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_cart> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
            
        }


    }
}
