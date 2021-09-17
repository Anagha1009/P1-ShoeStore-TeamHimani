using Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
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
                pro.product_image = products.product_image;
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

        public IEnumerable<tb_category> getCategory()
        {
            return db.tb_category.ToList();
        }

        public IEnumerable<tb_store> getStore()
        {
            return db.tb_store.ToList();
        }
    }
}
