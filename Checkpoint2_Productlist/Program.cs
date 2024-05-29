using Checkpoint2_Productlist;


void Main()
{
    List<Product> products = new List<Product>();
    ProductList pl = new ProductList();

    pl.ReadCategoryProductNamePrice(products);  

    pl.PrintAllProducts(products);


    string choice = "";
    while (choice.Trim().ToLower() != "q")
    {
        pl.WriteUserQue("PS");
        choice = Console.ReadLine();
        if (choice.Trim().ToLower() == "p")
        {
            // Console.WriteLine("P");

            pl.ReadCategoryProductNamePrice(products);

            pl.PrintAllProducts(products);

            //.............
        }
        else if (choice.Trim().ToLower() == "s")
        {
            pl.PrintAllProducts(products);
            pl.SearchProduct(products);
        }
        else if (choice.Trim().ToLower() == "q")
        {
            break;
        }
    }
}

Main();
