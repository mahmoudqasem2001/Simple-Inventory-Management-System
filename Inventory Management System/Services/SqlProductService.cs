using System;
using System.Data.SqlClient;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.Services
{
    public class SqlProductService : IInventoryService
    {
        private readonly string _connectionString;

        public SqlProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Product added to SQL Server.");
        }

        public void ViewProducts()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Name, Price, Quantity FROM Products";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name: {reader["Name"]}, Price: {reader["Price"]}, Quantity: {reader["Quantity"]}");
                    }
                }
            }
        }

        public bool EditProduct(string name, string newName, decimal? newPrice, int? newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Products SET Name = @NewName, Price = @NewPrice, Quantity = @NewQuantity WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@NewName", newName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NewPrice", newPrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NewQuantity", newQuantity ?? (object)DBNull.Value);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteProduct(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Products WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        public Product SearchProduct(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Name, Price, Quantity FROM Products WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product(
                                reader["Name"].ToString(),
                                (decimal)reader["Price"],
                                (int)reader["Quantity"]
                            );
                        }
                    }
                }
            }

            Console.WriteLine($"Product {name} not found in SQL Server.");
            return null; 
        }
    }
}
