using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoeconsole
{
   public class Product
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public int Store_Id { get; set; }
        public string Store_Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public bool Type { get; set; }
    }
}
