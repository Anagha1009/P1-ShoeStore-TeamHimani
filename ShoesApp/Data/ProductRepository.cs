using Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public tb_products GetProductById(int id)
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
            db.SaveChanges();
        }

        public void UpdateProduct(int id)
        {
            var pro = db.tb_products.Where<tb_products>(p => p.product_id == id).First();
            //var product = db.tb_products.Find(id);
            if (pro != null)
            {
                db.tb_products.AddOrUpdate(pro);
                Save();
            }
            else
                throw new ArgumentException("product is not found");
        }
        //Category table
       
    }
}
