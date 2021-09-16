using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
using Data.Entites;



namespace shoeconsole
{
    class Program
    {
        static void Main(string[] args)
        {
             
             ProductRepository prod = new ProductRepository(new ProductModel());
            
            //getproduct(prod);
            Console.WriteLine("enter a id");
            int id = Convert.ToInt32(Console.ReadLine());
            Getproductbyid(prod, id);
            // prod.DeleteProduct(id);
            updateproduct(prod, id);
            getproduct(prod);
        }
        public static void Getproductbyid(ProductRepository prod,int id)
        {
           
            var getproductbyid = prod.GetProductById(id);
            
            Console.Write("\n id" + getproductbyid.product_id);
            Console.Write("\n Name" + getproductbyid.product_name);
            Console.Write("\n Category" + getproductbyid.category_id);
            Console.Write("\n store" + getproductbyid.store_id);
            

            Console.ReadLine();
        }
        public static void getproduct(ProductRepository prod)
        {
           
            var product = prod.GetProducts();
            var data = new List<Product>();
            foreach (var pro in product)
            {
                Console.Write("\n id" + pro.product_id);
                Console.Write("\n Name" + pro.product_name);
                Console.Write("\n Category" + pro.category_id);
                Console.Write("\n store" + pro.store_id);
                
                

            }
            Console.ReadLine();
        }
        public static void updateproduct(ProductRepository prod,int id)
        {
            var getproductbyid = prod.GetProductById(id);
            Console.WriteLine("Type new values");
            getproductbyid.product_name = Console.ReadLine();
            prod.UpdateProduct(id);
        }
        //public static void addproduct(ProductRepository prod)
        //{
        //    Product z=new()
        //    Console.WriteLine("TYpe new values");
        //    tb_product product_name = Console.ReadLine();
        //}
    }
}
