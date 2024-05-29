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

    void WriteUserQue(string color)
    {
        if (color == "Y")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To enter a new Product - follow the steps | to quit enter 'Q'");
        }
        else if (color == "B")
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

        WriteUserQue("Y");

        while (true)
        {
            bool categoryOk = false;

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

            SuccessMessage();
        }
    }

    
    void HeaderForList()
    {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Category".PadRight(15) + "ProductName".PadRight(15) + "Price");
          Console.ResetColor();
    }

    void PrintAllProducts(List<Product> prods)
    {
        Console.WriteLine("");
        HeaderForList();
        foreach (var prod in prods)
        {
            Console.WriteLine(prod.Category.PadRight(15) + prod.ProductName.PadRight(15) + prod.Price);
        }
    }

void Main()
{
    List<Product> products = new List<Product>();

    ReadCategoryProductNamePrice(products);  // gör om till antingen "out data" eller string d = ReadCategoryProductName

    PrintAllProducts(products);
}

Main();
