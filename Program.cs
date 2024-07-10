
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Robe",
        Price = 82.00M,
        Sold = false,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Polyjuice Potion",
        Price = 44.00M,
        Sold = false,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Invisibility Cloak",
        Price = 299.00M,
        Sold = false,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Elder Wand",
        Price = 999.00M,
        Sold = true,
        ProductTypeId = 4
    },
};

string greeting = "Welcome to Reductio & Absurdum!";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Please select an option:
                        0. Exit
                        1. View All Products
                        2. Add Product to Inventory
                        3. Remove Product from Inventory
                        4. Update Product Details");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Exit Program");
    }
    else if (choice == "1")
    {
        Console.WriteLine("All Products:");
        ListProducts();
    }
    else if (choice == "2")
    {
        Console.WriteLine("Add Product to Inventory");
    }
    else if (choice == "3")
    {
        Console.WriteLine("Remove Product from Inventory");
    }
    else if (choice == "4")
    {
        Console.WriteLine("Update Product Details");
    }
}

void ListProducts()
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}