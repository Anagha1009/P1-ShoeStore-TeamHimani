using Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.IO;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        UserModel um = new UserModel();
        private ProductModel db;
        public ProductRepository(ProductModel db)
        {
            this.db = db;
        }

        public void AddProduct(tb_products product)
        {
            db.tb_products.Add(product);
            Save();

        }

        public int GetMaxProductId()
        {
            int id = db.tb_products.Max(cc => cc.product_id);
            return id;
        }

        public void DeleteProduct(int id)
        {            
            var pro = db.tb_products.Find(id);
            if (pro != null)
            {
                db.tb_products.Remove(pro);
                Save();
                
            }
            else
                throw new ArgumentException("product is not found");
        }

        public tb_products GetProductById(int? id)
        {
            if (id > 0)
            {
                var pro = db.tb_products
                   
                    .Include(c => c.tb_store)
                    .Where(c => c.product_id == id)
                    .FirstOrDefault();
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

        public IEnumerable<tb_products> GetProducts()
        {
            return db.tb_products
                .ToList();
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public tb_products UpdateProduct(int? id, tb_products products)
        {
            //var pro = db.tb_products.Where<tb_products>(p => p.product_id == id).First();
            var pro = db.tb_products.Find(id);
            if (pro != null)
            {
                //db.Entry(pro).State = EntityState.Modified;
                pro.product_name = products.product_name;
                pro.product_image = String.IsNullOrEmpty(products.product_image) ? "NULL" : products.product_image;
                pro.product_price = products.product_price;
                pro.product_quantity = products.product_quantity;
                pro.category_id = products.category_id;
                pro.store_id = products.store_id;

                db.SaveChanges();
                return pro;
            }
            else
                return pro;
        }

        public string CheckUserRole(string username)
        {
            var role = um.tb_users.Where(e => e.username == username).FirstOrDefault().role;
            
            if(role != null)
            {
                return role;
            }
            else
            {
                return "";
            }
            throw new NotImplementedException();
        }
        public IEnumerable<tb_category> getCategory()
        {
            return db.tb_category.ToList();
        }

        public IEnumerable<tb_store> getStore()
        {
            return db.tb_store.ToList();
        }
        public IEnumerable<tb_color> getColor()
        {
            return db.tb_color.ToList();
        }
        
        public IEnumerable<tb_sizes> getSize()
        {
            return db.tb_sizes.ToList();
        }

        public bool CheckColorAvailability(int? selectedcolorid, int? productid)
        {
            var id = db.tb_productcolor.Where(e => e.color_id == selectedcolorid && e.product_id == productid).FirstOrDefault();

            if(id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckSizeAvailability(int? selectedsizeid, int? productid)
        {
            var id = db.tb_productsize.Where(e => e.size_id == selectedsizeid && e.product_id == productid).FirstOrDefault();

            if (id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
