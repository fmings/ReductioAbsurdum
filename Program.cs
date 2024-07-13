
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

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Potions"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Enchanted Objects"
    },
    new ProductType()
    {
        Id = 4,
        Name = "Wands"
    }
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
        AddProduct();
    }
    else if (choice == "3")
    {
        RemoveProduct();
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
        var productType = productTypes.FirstOrDefault(p => p.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1}. Product: {products[i].Name}, Type: {productType?.Name}, Price:{products[i].Price}, Availablility: {(products[i].Sold ? "Not Available" : "Available")} ");
    }
}

void AddProduct()
{
    Console.WriteLine("Enter the name of the product:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the price of the product (x.xx format):");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Select the product type:");
    {
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
        }
    }
    int id = int.Parse(Console.ReadLine());

    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        Sold = false,
        ProductTypeId = id,
    };

    Console.WriteLine("Your product has been added!");
}

void RemoveProduct()
{
    ListProducts();
    Console.WriteLine("Please enter the number of which product you would like to remove:");
    int selectedProduct;
    if (int.TryParse(Console.ReadLine(), out selectedProduct) && selectedProduct > 0 && selectedProduct <= products.Count)
    {
        products.RemoveAt(selectedProduct - 1);
    }
    else
    {
        Console.WriteLine("Invalid entry. Please enter a valid number.");
    }
    Console.WriteLine("Remaining Product:");
    ListProducts();
}

void UpdateProduct()
{

}