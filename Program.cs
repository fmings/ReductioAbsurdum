
using System.Numerics;
using System.Xml.Linq;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Robe",
        Price = 82.00M,
        Sold = false,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 3, 15)
    },
    new Product()
    {
        Name = "Polyjuice Potion",
        Price = 44.00M,
        Sold = false,
        ProductTypeId = 2,
        DateStocked = new DateTime(2021, 8, 16)
    },
    new Product()
    {
        Name = "Invisibility Cloak",
        Price = 299.00M,
        Sold = false,
        ProductTypeId = 3,
        DateStocked = new DateTime(2023, 10, 15)
    },
    new Product()
    {
        Name = "Elder Wand",
        Price = 999.00M,
        Sold = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 2, 25)
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
                        4. Update Product Details
                        5. Search by Product Type");
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
        UpdateProduct();
    }
    else if (choice == "5")
    {
        SearchByProductType();
    }
}

void ListProducts()
{
    for (int i = 0; i < products.Count; i++)
    {
        var productType = productTypes.FirstOrDefault(p => p.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1}. Product: {products[i].Name}, Type: {productType?.Name}, Price:{products[i].Price}, Availablility: {(products[i].Sold ? "Not Available" : "Available")}, Days on Shelf: {products[i].DaysOnShelf} ");
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
        DateStocked = DateTime.Now
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
    Console.WriteLine("Select which product you would like to update:");
    ListProducts();
    int selectedProduct;
    if (int.TryParse(Console.ReadLine(), out selectedProduct) && selectedProduct > 0 && selectedProduct <= products.Count)
    {
        var product = products[selectedProduct - 1];
        var productType = productTypes.FirstOrDefault(p => p.Id == product.ProductTypeId);
        Console.WriteLine(@$"Here are the current details of the product you chose:
                            Name: {product.Name}
                            Price: {product.Price}
                            Availability: {(product.Sold ? "Not Available" : "Available")}
                            Product Type: {productType?.Name}");
        Console.WriteLine(@"What would you like to update?
                            1. Name
                            2. Price
                            3. Availability
                            4. Product Type");
        int selectedChange;
        if (int.TryParse(Console.ReadLine(), out selectedChange) && selectedChange > 0 && selectedChange < 5)
        {
            if (selectedChange == 1)
            {
                Console.WriteLine("Please enter the updated name:");
                product.Name = Console.ReadLine();
            }
            else if (selectedChange == 2)
            {
                Console.WriteLine("Please enter the updated price (x.xx format)");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                {
                    product.Price = newPrice;
                }
                else
                {
                    Console.WriteLine("Invalid price format.");
                }
            }
            else if (selectedChange == 3)
            {
                Console.WriteLine("Is the product still available? (Y or N)");
                string availabilityInput = Console.ReadLine();
                if (availabilityInput == "Y")
                {
                    product.Sold = false;
                }
                else if (availabilityInput == "N")
                {
                    product.Sold = true;
                }
                else
                {
                    Console.WriteLine("Invalid input for availability.");
                }
            }
            else if (selectedChange == 4)
            {
                Console.WriteLine("Select the new product type:");
                {
                    for (int i = 0; i < productTypes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
                    }
                }
                if (int.TryParse(Console.ReadLine(), out int newTypeId) && newTypeId > 0 && newTypeId <= productTypes.Count)
                {
                    product.ProductTypeId = productTypes[newTypeId - 1].Id;
                }
                else
                {
                    Console.WriteLine("Invalid product type selection.");
                }
            }
        }


    }
    else
    {
        Console.WriteLine("Invalid entry. Please enter a valid number.");
    }
}

    void SearchByProductType()
    {
        Console.WriteLine("Please enter the product type you are looking for");
        foreach (ProductType productType in productTypes)
        {
            Console.WriteLine($"{productType.Id}. {productType.Name} ");
        }
        int productTypeSearch;
        if (int.TryParse(Console.ReadLine(), out productTypeSearch) && productTypeSearch > 0 && productTypeSearch < 5)
        {
            var matchingProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.ProductTypeId == productTypeSearch)
                {
                    matchingProducts.Add(product);
                }
            }

            Console.WriteLine("Search Results:");
            foreach (var product in matchingProducts)
            {
                var productType = productTypes.FirstOrDefault(p => p.Id == product.ProductTypeId);
                Console.WriteLine(@$"
                            Name: {product.Name}
                            Price: {product.Price}
                            Availability: {(product.Sold ? "Not Available" : "Available")}
                            Product Type: {productType?.Name}
                            Days on Shelf: {product.DaysOnShelf}");
            }
        }
        else
        {
            Console.WriteLine("Invalid entry. Please enter a valid number.");
        }

    }
