using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace ShoesWeb.Models
{
    public class Mapper
    {
        public static Product Map(tb_products product)
        {

            return new Product()
            {
                Product_Id = product.product_id,
                Product_Name = product.product_name,
                Store_Id = product.store_id,
                Store_Name = product.tb_store.store_name,
                Category_Id = product.category_id,
                Category_Name = product.tb_category.category_name,
                Price = product.product_price,
                Quantity = product.product_quantity,
                Image = product.product_image,
                
                
            };
        }
        public static tb_products Map(ShoesWeb.Models.Product product)
        {
            return new tb_products()
            {
                product_id = product.Product_Id,
                product_name = product.Product_Name,
                store_id = product.Store_Id,
                category_id = product.Category_Id,
                product_price = product.Price,
                product_quantity = product.Quantity,
                product_image = product.Image,
                
            };
        }
       



    }
}