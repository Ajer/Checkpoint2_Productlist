using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2_Productlist
{
    public class Product
    {

        public Product(string prodName,string category,double price)
        {
            ProductName = prodName;
            Category = category;
            Price = price;
        }
        public string ProductName { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

    }
}
