using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entites;
using System.Data.Entity;

namespace Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private OrderModel db;
        CartItemModel cm = new CartItemModel();
        ProductModel pm = new ProductModel();
        public OrderRepository(OrderModel db)
        {
            this.db = db;
        }

        public void PlaceOrder(tb_order order, tb_orderdetails orderdetails, int cid)
        {
            if (cid > 0)
            {
                order.customer_id = cid;
                order.store_id = cm.tb_cartitem.Where<tb_cartitem>(p => p.customer_id == cid).FirstOrDefault().store_id;
                order.total_bill = Convert.ToDecimal(cm.tb_cartitem.Where<tb_cartitem>(p => p.customer_id == cid).Sum(x => x.product_price));
                order.date = DateTime.Now.Date;
                db.tb_order.Add(order);
                Save();
                
                var prodid = cm.tb_cartitem.Where<tb_cartitem>(p => p.customer_id == cid);

                int orderid = db.tb_order.Max(cc => cc.order_id);

                foreach (var p in prodid)
                {
                    orderdetails.order_id = orderid;
                    orderdetails.product_id = p.product_id;
                    db.tb_orderdetails.Add(orderdetails);
                    Save();
                }

                

                //Save();
                //var xe = d;
                //foreach (var p in prodid)
                //{
                //    var pro = cm.tb_cartitem.Find(p.cart_id);

                //    if (pro != null)
                //    {
                        
                //        cm.tb_cartitem.RemoveAll(pro);
                //        Save();
                //    }
                //}

                

                //foreach (tb_cartitem log in cm.tb_cartitem.Where<tb_cartitem>(p => p.customer_id == cid))
                //{
                //    cm.tb_cartitem.Remove(log);

                //}
                //Save();
            }
        }

        public IEnumerable<tb_order> ViewOrder(int cid)
        {
            if (cid > 0)
            {
                var pro = db.tb_order
                    .Where(c => c.customer_id == cid).ToList();
                if (pro != null)
                    return pro;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }

        public void Save()
        {
            db.SaveChanges();

        }

        //public void DeleteCart(int cid)
        //{
        //    var d = cm.tb_cartitem.Where<tb_cartitem>(p => p.customer_id == cid).ToList();

        //    foreach(var v in d)
        //    {
        //        var pro = cm.tb_cartitem.Find(v.cart_id);
        //        if (pro != null)
        //        {
        //            cm.tb_cartitem.Remove(pro);
        //            Save();

        //        }
        //        else
        //            throw new ArgumentException("product is not found");
        //    }            
        //}

        public void DeleteInventory(int? pid)
        {
            //var quantity = pm.tb_products.Where<tb_products>(p => p.product_id == pid).FirstOrDefault();
            //quantity.product_quantity = quantity.product_quantity - 1;

            var pro = pm.tb_products.Find(pid);
            pro.product_quantity = pro.product_quantity - 1;
            pm.SaveChanges();
        }

        public bool CheckInventory(int? pid)
        {
            var quantity = pm.tb_products.Where<tb_products>(p => p.product_id == pid).FirstOrDefault().product_quantity;

            if(quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<tb_order> GetOrder()
        {
            return db.tb_order
                .ToList();
        }

        public IEnumerable<tb_store> getStore()
        {
            return pm.tb_store.ToList();
        }
    }


}
