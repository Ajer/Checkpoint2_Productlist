using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2_Productlist
{
    public class ProductList
    {

        public ProductList()
        {           
        }

        public string ReadDataFromUser(string userAction)
        {
            Console.Write(userAction + ": "); //exempel  userAction = "Enter a Category"
            string? data = Console.ReadLine();

            if (data != null)
            {
                if (data.Trim().ToLower() != "q")   // data Ok
                {
                    return data.Trim();
                }
                else if (data.Trim().ToLower() == "q")
                {
                    return "q";
                }
            }
            return "";
        }

        public void WriteUserQue(string type)
        {
            if (type == "P")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new Product - follow the steps | to quit enter 'Q'");
            }
            else if (type == "PS")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("To enter a new Product - enter: \"P\" | To search for a product - enter: \"S\" | To quit enter 'Q'");
            }
            Console.ResetColor();
        }

        public void SuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Product was successfully added");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------");
        }


        public void ReadCategoryProductNamePrice(List<Product> products)
        {

            string dataCategory = "";
            string dataProductName = "";
            string dataPrice = "";


            while (true)
            {
                bool categoryOk = false;

                WriteUserQue("P");

                Console.WriteLine();
                while (!categoryOk)
                {
                    dataCategory = ReadDataFromUser("Enter a Category");
                    if (dataCategory != "")  // antingen "q" eller annan data gör dig fri från loopen
                    {
                        categoryOk = true;
                    }
                }
                if (dataCategory.ToLower() == "q")
                {
                    break;
                }

                bool productNameOk = false;
                while (!productNameOk)
                {
                    dataProductName = ReadDataFromUser("Enter a Product Name");
                    if (dataProductName != "")
                    {
                        productNameOk = true;
                    }
                }
                if (dataProductName.ToLower() == "q")
                {
                    break;
                }

                bool priceOk = false;
                double price = 0;
                while (!priceOk)
                {
                    dataPrice = ReadDataFromUser("Enter a Price");
                    if (dataPrice != "")
                    {
                        try
                        {
                            price = Convert.ToDouble(dataPrice);
                            priceOk = true;
                        }
                        catch (Exception e)
                        {
                            if (dataPrice.ToLower() == "q")
                            {
                                priceOk = true;
                            }
                            else
                            {
                                priceOk = false;
                            }
                        }
                    }
                }
                if (dataPrice.ToLower() == "q")
                {
                    break;
                }
                // All 3 datas here because no break has been performed


                Product p = new Product(dataProductName, dataCategory, price);

                products.Add(p);

                //write to file

                SuccessMessage();
            }
        }


        public void ListHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category".PadRight(20) + "ProductName".PadRight(20) + "Price");
            Console.ResetColor();
        }


        // Sort by ascending price
        public List<Product> DefaultSort(List<Product> prods)
        {
            return prods.OrderBy(item => item.Price).ToList();
        }


        public string ReadSearchProduct()
        {
            string? s = "";
            string str = "";
            while (true)
            {
                Console.Write("Enter a product to search for: ");
                s = Console.ReadLine();
                str = s.Trim().ToLower();
                if (!string.IsNullOrEmpty(s) || str.Equals("q"))
                {
                    break;
                }
            }
            return str;
        }


        public void PrintAllProducts(List<Product> prods,string search="")
        {
            double sum = prods.Sum(item => item.Price);
            var defaultSorted = DefaultSort(prods); // default sort.ThenBy(item => item.ProductName).ToList();

            bool srch = (search != "") ? true:false;
            bool found = false;

            if (srch)
            {
                Product? searchP = defaultSorted.First(item => item.ProductName.ToLower().Equals(search));
                if (searchP!=null)     // sökt produkt hittad
                {
                    found = true;
                }
                else
                {
                    found = false;
                }
            }

            Console.WriteLine("");
            ListHeader();
            Console.WriteLine("---------------------------------------------");

            if (srch && found)
            {

                foreach (var prod in defaultSorted)
                {

                    if (prod.ProductName.ToLower().Equals(search))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine(prod.Category.PadRight(20) + prod.ProductName.PadRight(20) + prod.Price);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(prod.Category.PadRight(20) + prod.ProductName.PadRight(20) + prod.Price);
                    }
                }
            }
            else if (srch && !found)
            {
                Console.WriteLine("The Item was not found");
            }
            else   // normal-visning utan sökning
            {
                foreach (var prod in defaultSorted)   
                {
                    Console.WriteLine(prod.Category.PadRight(20) + prod.ProductName.PadRight(20) + prod.Price);
                }            
            }
            Console.WriteLine();

            Console.WriteLine("Total Amount:".PadRight(40) + sum.ToString());
            Console.WriteLine("---------------------------------------------");
        }
    }
}
