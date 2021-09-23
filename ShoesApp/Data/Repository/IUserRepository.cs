using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    interface IUserRepository
    {
       
        void RegisterCustomer (tb_users user,tb_customers customer);
        string LoginCustomer(tb_users user);
        void LoginAdmin(tb_users user);
        void Save();

        //nikita

        IEnumerable<tb_customers> GetCustomer();
    }
}
