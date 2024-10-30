using Inventory_Management_System.Models;
using System.Collections.Generic;

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
