using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
   public class UserRepository : IUserRepository
    {
        private UserModel db;
        public UserRepository(UserModel db)
        {
            this.db = db;
        }

        public void LoginAdmin(tb_users user)
        {

            throw new NotImplementedException();
        }

        public string LoginCustomer(tb_users user)
        {
          var validatecustomer= db.tb_users.Where(e => e.username == user.username && e.password == user.password).FirstOrDefault();
            if ( validatecustomer != null)
            {
               string valicust=validatecustomer.ToString();
                return valicust = user.username;
            }
            else
            {
                return null;
            }
        }

        public void RegisterCustomer(tb_users user, tb_customers customer)
        {
            try
            {
                user.role = "customer";
                db.tb_users.Add(user);
                Save();
                customer.user_id = db.tb_users.Max(p => p.user_id);
                db.tb_customers.Add(customer);
                Save();

            }

            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        //nikita

        public IEnumerable<tb_customers> GetCustomer()
        {
            return db.tb_customers
                .ToList();

        }
    }
}
