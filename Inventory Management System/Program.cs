using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Inventory_Management_System.Services;
using System;

namespace Inventory_Management_System
{
    public class Program
    {
        private static IInventoryService _inventory;

        public static void Main(string[] args)
        {
            Console.WriteLine("Choose database to use:");
            Console.WriteLine("1. SQL Server");
            Console.WriteLine("2. MongoDB");
            Console.Write("Enter choice: ");
            var dbChoice = Console.ReadLine();

            switch (dbChoice)
            {
                case "1":
                    Console.Write("Enter SQL Server connection string: ");
                    var sqlConnectionString = Console.ReadLine();
                    _inventory = new SqlProductService(sqlConnectionString);
                    break;

                case "2":
                    Console.Write("Enter MongoDB connection string: ");
                    var mongoConnectionString = Console.ReadLine();
                    Console.Write("Enter MongoDB database name: ");
                    var mongoDatabaseName = Console.ReadLine();
                    _inventory = new MongoProductService(mongoConnectionString, mongoDatabaseName);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Exiting program.");
                    return;
            }

            RunProgramLoop();
        }

        private static void RunProgramLoop()
        {
            while (true)
            {
                Console.WriteLine("\nSimple Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Edit Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ViewProducts();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddProduct()
        {
            Console.Write("Enter product name: ");
            var name = Console.ReadLine();

            Console.Write("Enter product price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price. Operation cancelled.");
                return;
            }

            Console.Write("Enter product quantity: ");
            if (!int.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Invalid quantity. Operation cancelled.");
                return;
            }

            var product = new Product(name, price, quantity);
            _inventory.AddProduct(product);
            Console.WriteLine($"Product {name} added successfully.");
        }

        private static void ViewProducts()
        {
            _inventory.ViewProducts();
        }

        private static void EditProduct()
        {
            Console.Write("Enter product name to edit: ");
            var name = Console.ReadLine();

            Console.Write("Enter new name (leave empty to keep current): ");
            var newName = Console.ReadLine();

            Console.Write("Enter new price (leave empty to keep current): ");
            decimal? newPrice = null;
            if (decimal.TryParse(Console.ReadLine(), out var price))
            {
                newPrice = price;
            }

            Console.Write("Enter new quantity (leave empty to keep current): ");
            int? newQuantity = null;
            if (int.TryParse(Console.ReadLine(), out var quantity))
            {
                newQuantity = quantity;
            }

            if (_inventory.EditProduct(name, newName, newPrice, newQuantity))
            {
                Console.WriteLine($"Product {name} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Product {name} not found.");
            }
        }

        private static void DeleteProduct()
        {
            Console.Write("Enter product name to delete: ");
            var name = Console.ReadLine();
            if (_inventory.DeleteProduct(name))
            {
                Console.WriteLine($"Product {name} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product {name} not found.");
            }
        }

        private static void SearchProduct()
        {
            Console.Write("Enter product name to search: ");
            var name = Console.ReadLine();

            var product = _inventory.SearchProduct(name);
            if (product == null)
            {
                Console.WriteLine($"Product {name} not found.");
            }
            else
            {
                Console.WriteLine(product);
            }
        }
    }
}
