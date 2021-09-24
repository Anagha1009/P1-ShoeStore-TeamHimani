using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entites;

namespace Data.Repository
{
    interface ICartItemRepository
    {
        int? AddCartItems(tb_cartitem cartitems, int? id, int cid, int? Color, int? Size);

        IEnumerable<tb_cartitem> ViewCartItems(int cid);

        void DeleteCart(int id);

        int GetCartItemsCount(int cid);
    }
}
