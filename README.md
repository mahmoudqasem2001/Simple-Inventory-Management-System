# Simple Inventory Management System

## Overview

The **Simple Inventory Management System** is a console-based application developed in C#. This system allows users to manage an inventory of products, including adding, viewing, editing, deleting, and searching for products. It serves as a basic example of how to implement object-oriented principles and clean code architecture in a C# application.

## Features

- **Add a Product**: Users can add new products to the inventory by specifying the product name, price, and quantity.
- **View All Products**: Displays a list of all products currently in the inventory, including their names, prices, and quantities.
- **Edit a Product**: Allows users to update the name, price, or quantity of an existing product.
- **Delete a Product**: Users can remove a product from the inventory by specifying the product name.
- **Search for a Product**: Users can search for a product by name and view its details if it exists in the inventory.

## Project Structure

The project is organized into the following directories:

- **src/**: Contains all source code and project files.
  - **Models/**: Contains data models such as `Product`.
  - **Services/**: Contains business logic such as `InventoryService`.
  - **Interfaces/**: Contains interface definitions like `IInventoryService` for service contracts.

## Installation

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or higher
- Git

### Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/SimpleInventoryManagementSystem.git
    ```
2. Navigate to the project directory:
    ```bash
    cd SimpleInventoryManagementSystem/src/SimpleInventoryManagementSystem
    ```
3. Restore dependencies (if any):
    ```bash
    dotnet restore
    ```
4. Build the project:
    ```bash
    dotnet build
    ```
5. Run the application:
    ```bash
    dotnet run
    ```

## Usage

Upon running the application, you will be presented with a menu to choose from the following options:

1. **Add Product**: Enter the product name, price, and quantity to add it to the inventory.
2. **View Products**: Displays a list of all products in the inventory.
3. **Edit Product**: Allows you to update the name, price, or quantity of a product by specifying its name.
4. **Delete Product**: Removes a product from the inventory by specifying its name.
5. **Search Product**: Search for a product by name and view its details.
6. **Exit**: Closes the application.


---

Feel free to modify this `README.md` as needed to reflect your specific project details.


