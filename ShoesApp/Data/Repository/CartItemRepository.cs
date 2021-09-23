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
        public int? AddCartItems(tb_cartitem cartitems, int? id, int cid,int? Color,int? Size)
        {

            cartitems.customer_id = cid;
            int? storeid = pm.tb_products.Where(e => e.product_id == id).FirstOrDefault().store_id;
            cartitems.store_id = storeid;
            cartitems.product_id = id;
            cartitems.color = pm.tb_color.Where(e => e.color_id == Color).FirstOrDefault().color;
            cartitems.size = pm.tb_sizes.Where(e => e.size_id == Size).FirstOrDefault().size;
            cartitems.product_price = pm.tb_products.Where(e => e.product_id == id).FirstOrDefault().product_price;
            db.tb_cartitem.Add(cartitems);
            Save();
            return storeid;
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

        public void DeleteCart(int id)
        {
            var pro = db.tb_cartitem.Find(id);
            if (pro != null)
            {
                db.tb_cartitem.Remove(pro);
                Save();

            }
            else
                throw new ArgumentException("product is not found");
        }
    }
}
