using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entites;
using System.Data.Entity;

namespace Data.Repository
{
    public class CartItemRepository:ICartItemRepository
    {
        private CartItemModel db;
        ProductModel pm = new ProductModel();
        public CartItemRepository(CartItemModel db)
        {
            this.db = db;
        }
        public void AddCartItems(tb_cartitem cartitems, int? id, int cid)
        {
            cartitems.customer_id = cid;
            cartitems.store_id = pm.tb_products.Where(e => e.product_id == id).FirstOrDefault().store_id;
            cartitems.product_id = id;
            cartitems.color = "Blue";
            cartitems.size = 7;
            db.tb_cartitem.Add(cartitems);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();

        }

        public IEnumerable<tb_cartitem> ViewCartItems(int cid)
        {
            //return db.tb_cartitem
            //    .ToList();

            if (cid > 0)
            {
                var pro = db.tb_cartitem

                    .Include(c => c.tb_products)
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
    }
}
