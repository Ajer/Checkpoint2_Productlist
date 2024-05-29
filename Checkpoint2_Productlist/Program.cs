using Checkpoint2_Productlist;


void Main()
{
    List<Product> products = new List<Product>();
    ProductList pl = new ProductList();

    pl.ReadCategoryProductNamePrice(products);  // gör om till antingen "out data" eller string d = ReadCategoryProductName

    pl.PrintAllProducts(products);

    pl.WriteUserQue("PS");

    //while (true && choice.ToLower()!="q")
    //{
    //    WriteUserQue("PS");
    //    string choice = Console.ReadLine();

    //}
}

Main();
