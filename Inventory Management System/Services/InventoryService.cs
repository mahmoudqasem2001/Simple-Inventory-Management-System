using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Services
{
    public class InventoryService : IInventoryService
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Product {product.Name} added successfully.");
        }

        public void ViewProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }

        public bool EditProduct(string name, string newName, decimal? newPrice, int? newQuantity)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine($"Product {name} not found.");
                return false;
            }

            if (!string.IsNullOrEmpty(newName)) product.Name = newName;
            if (newPrice.HasValue) product.Price = newPrice.Value;
            if (newQuantity.HasValue) product.Quantity = newQuantity.Value;

            Console.WriteLine($"Product {name} updated successfully.");
            return true;
        }

        public bool DeleteProduct(string name)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine($"Product {name} not found.");
                return false;
            }

            _products.Remove(product);
            Console.WriteLine($"Product {name} deleted successfully.");
            return true;
        }

        public Product SearchProduct(string name)
        {
            return _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
