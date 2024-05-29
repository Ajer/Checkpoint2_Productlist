using Checkpoint2_Productlist;

    string ReadDataFromUser(string userAction)
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

    void WriteUserQue(string type)
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

    void SuccessMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Product was successfully added");
        Console.ResetColor();
        Console.WriteLine("-----------------------------------------");
    }

    

    void ReadCategoryProductNamePrice(List<Product> products)
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

    
    void ListHeader()
    {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Category".PadRight(20) + "ProductName".PadRight(20) + "Price");
          Console.ResetColor();
    }

    void PrintAllProducts(List<Product> prods)
    {
        double sum = prods.Sum(item => item.Price);
        var defaultSorted = prods.OrderBy(item => item.Price).ToList(); // default sort.ThenBy(item => item.ProductName).ToList();

        Console.WriteLine("");
        ListHeader();
        Console.WriteLine("---------------------------------------------");
        foreach (var prod in defaultSorted)
        {
            Console.WriteLine(prod.Category.PadRight(20) + prod.ProductName.PadRight(20) + prod.Price);
        }
        Console.WriteLine();

        Console.WriteLine("Total Amount:".PadRight(40) + sum.ToString());
        Console.WriteLine("---------------------------------------------");
    }

void Main()
{
    List<Product> products = new List<Product>();

    ReadCategoryProductNamePrice(products);  // gör om till antingen "out data" eller string d = ReadCategoryProductName

    PrintAllProducts(products);

    //while (true)
    //{
    //    WriteUserQue("PS");
    //}
}

Main();
