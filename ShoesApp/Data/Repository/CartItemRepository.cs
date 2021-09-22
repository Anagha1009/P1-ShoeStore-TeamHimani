using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entites;

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
            Save();
        }
        public void Save()
        {
            db.SaveChanges();

        }
    }
}
