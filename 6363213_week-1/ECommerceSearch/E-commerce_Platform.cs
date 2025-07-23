/* Exercise 2: E-commerce Platform Search Function
Scenario: 
You are working on the search functionality of an e-commerce platform. The search needs to be optimized for fast performance.
Steps:
1.Understand Asymptotic Notation:
oExplain Big O notation and how it helps in analyzing algorithms.
oDescribe the best, average, and worst-case scenarios for search operations.
2.Setup:
oCreate a class Product with attributes for searching, such as productId, productName, and category.
3.Implementation:
oImplement linear search and binary search algorithms.
oStore products in an array for linear search and a sorted array for binary search.
4.Analysis:
oCompare the time complexity of linear and binary search algorithms.
oDiscuss which algorithm is more suitable for your platform and why.*/

using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class SearchManager
{
    public static int LinearSearch(List<Product> products, string targetName)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }

    public static int BinarySearch(List<Product> sortedProducts, string targetName)
    {
        int low = 0, high = sortedProducts.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int compare = string.Compare(sortedProducts[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

            if (compare == 0)
                return mid;
            else if (compare < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        while (true)
        {
            Console.WriteLine("\n===== E-Commerce Platform Menu =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Linear Search");
            Console.WriteLine("3. Binary Search (sorted)");
            Console.WriteLine("4. View All Products");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Product ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();

                    products.Add(new Product
                    {
                        ProductId = id,
                        ProductName = name,
                        Category = category
                    });
                    Console.WriteLine("Product added successfully.");
                    break;

                case "2":
                    Console.Write("Enter product name to search (Linear Search): ");
                    string searchLinear = Console.ReadLine();
                    int indexLinear = SearchManager.LinearSearch(products, searchLinear);
                    if (indexLinear >= 0)
                        Console.WriteLine("Product found: " + products[indexLinear]);
                    else
                        Console.WriteLine("Product not found.");
                    break;

                case "3":
                    List<Product> sortedProducts = new List<Product>(products);
                    sortedProducts.Sort((a, b) => a.ProductName.CompareTo(b.ProductName));

                    Console.Write("Enter product name to search (Binary Search): ");
                    string searchBinary = Console.ReadLine();
                    int indexBinary = SearchManager.BinarySearch(sortedProducts, searchBinary);
                    if (indexBinary >= 0)
                        Console.WriteLine("Product found: " + sortedProducts[indexBinary]);
                    else
                        Console.WriteLine("Product not found.");
                    break;

                case "4":
                    Console.WriteLine("\nAll Available Products:");
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                    break;

                case "5":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
