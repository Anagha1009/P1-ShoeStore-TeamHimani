using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entites;

namespace Data.Repository
{
    interface IOrderRepository
    {
        IEnumerable<tb_order> ViewOrder(int cid);

        void PlaceOrder(tb_order order,tb_orderdetails orderdetails, int cid);

        void Save();
    }
}
