using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    interface ICartRepository
    {
        IEnumerable<tb_cart> GetCartItems();
        void AddCartItems(tb_cart cart,tb_cartdetails cartdetails,int? id,int cid);
        // tb_products UpdateProduct(int? id, tb_products product);
        //IEnumerable<string> ViewCart(int? cid);

        void DeleteCartItems(int id);
        void Save();
    }
}
