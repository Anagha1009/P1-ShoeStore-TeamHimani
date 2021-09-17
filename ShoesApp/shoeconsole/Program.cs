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

            getproduct(prod);

            Console.WriteLine("\nAdding new product");
            addproduct(prod);
            getproduct(prod);

            Console.WriteLine("\nEnter a Id to fetch a product");
            int id = Convert.ToInt32(Console.ReadLine());
            Getproductbyid(prod, id);

            Console.WriteLine("\nEnter a Id to delete a product");
            int id1 = Convert.ToInt32(Console.ReadLine());
            prod.DeleteProduct(id1);
            getproduct(prod);

            Console.WriteLine("\nEnter a Id to update");
            int id2 = Convert.ToInt32(Console.ReadLine());
            updateproduct(prod, id2);
            getproduct(prod);

            

            
        }
        public static void Getproductbyid(ProductRepository prod, int id)
        {

            var getproductbyid = prod.GetProductById(id);

            if(getproductbyid != null)
            {
                Console.Write("\nID       Name         Category          Store\n\n");
                Console.Write(getproductbyid.product_id + "        " + 
                    getproductbyid.product_name + "         " + 
                    getproductbyid.tb_category.category_name + "            " + 
                    getproductbyid.tb_store.store_name);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Cannot find Id");
                Console.WriteLine("Enter a id to fetch a product");
                int id2 = Convert.ToInt32(Console.ReadLine());
                Getproductbyid(prod, id2);
            }
        }
        public static void getproduct(ProductRepository prod)
        {
            var product = prod.GetProducts();
            Console.Write("\nID       Name         Category          Store\n\n");
            foreach (var pro in product)
            {               
                Console.Write(pro.product_id + "        " + pro.product_name + "         " + pro.tb_category.category_name + "            " + pro.tb_store.store_name + "\n");
            }
            Console.ReadLine();
        }
        public static void updateproduct(ProductRepository prod, int id)
        {
            var getproductbyid = prod.GetProductById(id);
            Console.WriteLine("\nType new value for Name");
            getproductbyid.product_name = Console.ReadLine();
            prod.UpdateProduct(id);
        }
        public static void addproduct(ProductRepository prod)
        {
            tb_products producttb = new tb_products();

            Console.WriteLine("\nEnter Product Name");
            var productName = Console.ReadLine();
            producttb.product_name = productName;

            Console.WriteLine("\nEnter Category Id");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            producttb.category_id = categoryId;

            Console.WriteLine("\nEnter Store Id");
            int storeId = Convert.ToInt32(Console.ReadLine());
            producttb.store_id = storeId;

            Console.WriteLine("\nEnter Product Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            producttb.product_quantity = quantity;

            Console.WriteLine("\nEnter Product Image Name");
            var imageName = Console.ReadLine();
            producttb.product_image = imageName;

            Console.WriteLine("\nEnter Product Type");
            var type = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            producttb.type = type;

            prod.AddProduct(producttb);
        }
    }
}
