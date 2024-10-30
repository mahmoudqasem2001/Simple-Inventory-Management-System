using MongoDB.Driver;
using Inventory_Management_System.Models;
using System;
using Inventory_Management_System.Interfaces;

namespace Inventory_Management_System.Services
{
    public class MongoProductService : IInventoryService
    {
        private readonly IMongoCollection<Product> _products;

        public MongoProductService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _products = database.GetCollection<Product>("Products");
        }

        public void AddProduct(Product product)
        {
            _products.InsertOne(product);
            Console.WriteLine("Product added to MongoDB.");
        }

        public void ViewProducts()
        {
            var products = _products.Find(_ => true).ToList();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public bool EditProduct(string name, string newName, decimal? newPrice, int? newQuantity)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            var update = Builders<Product>.Update
                .Set(p => p.Name, newName ?? name)
                .Set(p => p.Price, newPrice)
                .Set(p => p.Quantity, newQuantity);

            var result = _products.UpdateOne(filter, update);
            return result.ModifiedCount > 0;
        }

        public bool DeleteProduct(string name)
        {
            var result = _products.DeleteOne(p => p.Name == name);
            return result.DeletedCount > 0;
        }

        public Product SearchProduct(string name)
        {
            return _products.Find(p => p.Name == name).FirstOrDefault();
        }
    }
}
