using System;
using System.Collections.Generic;
using System.Linq;

public partial class Program
{
    public static void Main(string[] args)
    {
        // Create a "productTypes" variable here with a List of ProductTypes
        var productTypes = new List<ProductType>
        {
            new ProductType { Id = 1, Title = "Brass" },
            new ProductType { Id = 2, Title = "Poem" }
        };

        // Create a "products" variable here to include at least five Product instances
        var products = new List<Product>
        {
            new Product { Name = "Trumpet", Price = 150.99M, ProductTypeId = 1 },
            new Product { Name = "Trombone", Price = 246.99M, ProductTypeId = 1 },
            new Product { Name = "Tuba", Price = 1250.99M, ProductTypeId = 1 },
            new Product { Name = "Ozymandias", Price = 12350.99M, ProductTypeId = 2 },
            new Product { Name = "Leaves of Grass", Price = 15650.99M, ProductTypeId = 2 }
        };

        // Put your greeting here
        Console.WriteLine("🎺 Welcome to Brass & Poem! 📚");

        // Implement your loop here
        bool exit = false;
    while (!exit)
    {
        DisplayMenu();
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                DisplayAllProducts(products, productTypes);
                break;
            case "2":
                DeleteProduct(products, productTypes);
                break;
            case "3":
                AddProduct(products, productTypes);
                break;
            case "4":
                UpdateProduct(products, productTypes);
                break;
            case "5":
                Console.WriteLine("Goodbye! Thank you for using Brass & Poem.");
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        if (!exit)
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Display all products");
        Console.WriteLine("2. Delete a product");
        Console.WriteLine("3. Add a new product");
        Console.WriteLine("4. Update product properties");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
    }

    public static void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {
        if (!products.Any())
        {
            Console.WriteLine("No products available.");
            return;
        }

        for (int i = 0; i < products.Count; i++)
        {
            var product = products[i];
            var productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
            Console.WriteLine($"{i + 1}. {product.Name} - {product.Price:C} ({productType?.Title ?? "Unknown Type"})");
        }
    }

    public static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        DisplayAllProducts(products, productTypes);
        Console.Write("Enter the number of the product to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= products.Count)
        {
            var deletedProduct = products[index - 1];
            products.RemoveAt(index - 1);
            Console.WriteLine($"{deletedProduct.Name} has been removed.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public static void AddProduct(List<Product> products, List<ProductType> productTypes)
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the product price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Invalid price. Product not added.");
            return;
        }

        Console.WriteLine("Choose a product type:");
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        }
        if (int.TryParse(Console.ReadLine(), out int typeIndex) && typeIndex > 0 && typeIndex <= productTypes.Count)
        {
            int productTypeId = productTypes[typeIndex - 1].Id;
            products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
            Console.WriteLine($"{name} has been added to the inventory.");
        }
        else
        {
            Console.WriteLine("Invalid product type. Product not added.");
        }
    }

    public static void UpdateProduct(List<Product> products, List<ProductType> productTypes)
    {
        DisplayAllProducts(products, productTypes);
        Console.Write("Enter the number of the product to update: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= products.Count)
        {
            var productToUpdate = products[index - 1];

            Console.Write($"Enter new name (current: {productToUpdate.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                productToUpdate.Name = name;
            }

            Console.Write($"Enter new price (current: {productToUpdate.Price:C}): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                productToUpdate.Price = price;
            }

            Console.WriteLine("Choose a new product type:");
            for (int i = 0; i < productTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
            }
            if (int.TryParse(Console.ReadLine(), out int typeIndex) && typeIndex > 0 && typeIndex <= productTypes.Count)
            {
                productToUpdate.ProductTypeId = productTypes[typeIndex - 1].Id;
            }

            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
public partial class Program { }