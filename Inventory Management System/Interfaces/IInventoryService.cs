using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Interfaces
{
    public interface IInventoryService
    {
        void AddProduct(Product product);
        void ViewProducts();
        bool EditProduct(string name, string newName, decimal? newPrice, int? newQuantity);
        bool DeleteProduct(string name);
        Product SearchProduct(string name);
    }
}
