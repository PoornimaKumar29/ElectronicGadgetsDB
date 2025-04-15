using System;
using TechShopApp.dao;
using TechShopApp.entity;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TechShopApp.util;
namespace TechShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Opening database connection...");
                using (SqlConnection conn = DatabaseConnector.OpenConnection())
                {
                    Console.WriteLine("✅ Database connected successfully!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Failed to connect to the database.");
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Exiting application...");
                return;
            }

            ServiceProvider serviceProvider = new ServiceProvider();
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("TechShopApp Menu:");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Place Order");
                Console.WriteLine("6. Add Order Detail");
                Console.WriteLine("7. Get Order Status");
                Console.WriteLine("8. Add Inventory");
                Console.WriteLine("9. Update Inventory");
                Console.WriteLine("10. Remove Inventory");
                Console.WriteLine("11. Update Customer Account");
                Console.WriteLine("12. Process Payment");
                Console.WriteLine("13. Search Products");
                Console.WriteLine("14. Get Recommended Products");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Register Customer
                        Console.WriteLine("Enter Customer Details:");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();

                        Customer customer = new Customer
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            Phone = phone,
                            Address = address
                        };
                        serviceProvider.RegisterCustomer(customer);
                        Console.WriteLine("Customer Registered Successfully!");
                        break;

                    case 2:
                        // Add Product
                        Console.WriteLine("Enter Product Details:");
                        Console.Write("Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Product product = new Product
                        {
                            ProductName = productName,
                            Description = description,
                            Price = price
                        };
                        serviceProvider.AddProduct(product);
                        Console.WriteLine("Product Added Successfully!");
                        break;

                    case 3:
                        // Update Product
                        Console.Write("Enter Product ID to Update: ");
                        int updateProductID = int.Parse(Console.ReadLine());
                        Console.Write("Updated Product Name: ");
                        string updatedProductName = Console.ReadLine();
                        Console.Write("Updated Description: ");
                        string updatedDescription = Console.ReadLine();
                        Console.Write("Updated Price: ");
                        decimal updatedPrice = decimal.Parse(Console.ReadLine());

                        Product updatedProduct = new Product
                        {
                            ProductID = updateProductID,
                            ProductName = updatedProductName,
                            Description = updatedDescription,
                            Price = updatedPrice
                        };
                        serviceProvider.UpdateProduct(updatedProduct);
                        Console.WriteLine("Product Updated Successfully!");
                        break;

                    case 4:
                        // Remove Product
                        Console.Write("Enter Product ID to Remove: ");
                        int productIDToRemove = int.Parse(Console.ReadLine());
                        serviceProvider.RemoveProduct(productIDToRemove);
                        Console.WriteLine("Product Removed Successfully!");
                        break;

                    case 5:
                        // Place Order
                        Console.WriteLine("Enter Order Details:");
                        Console.Write("Customer ID: ");
                        int customerIDForOrder = int.Parse(Console.ReadLine());
                        Console.Write("Order Date (yyyy-mm-dd): ");
                        DateTime orderDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Total Amount: ");
                        decimal totalAmount = decimal.Parse(Console.ReadLine());

                        Order order = new Order
                        {
                            Customer = new Customer { CustomerID = customerIDForOrder },
                            OrderDate = orderDate,
                            TotalAmount = totalAmount
                        };
                        serviceProvider.PlaceOrder(order);
                        Console.WriteLine("Order Placed Successfully!");
                        break;

                    case 6:
                        // Add Order Detail
                        Console.WriteLine("Enter Order Detail:");
                        Console.Write("Order ID: ");
                        int orderIDForDetail = int.Parse(Console.ReadLine());
                        Console.Write("Product ID: ");
                        int productIDForDetail = int.Parse(Console.ReadLine());
                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        OrderDetail orderDetail = new OrderDetail
                        {
                            Order = new Order { OrderID = orderIDForDetail },
                            Product = new Product { ProductID = productIDForDetail },
                            Quantity = quantity
                        };
                        serviceProvider.AddOrderDetail(orderDetail);
                        Console.WriteLine("Order Detail Added Successfully!");
                        break;

                    case 7:
                        // Get Order Status
                        Console.Write("Enter Order ID to Get Status: ");
                        int orderIDToCheck = int.Parse(Console.ReadLine());
                        string orderStatus = serviceProvider.GetOrderStatus(orderIDToCheck);
                        Console.WriteLine($"Order Status: {orderStatus}");
                        break;

                    case 8:
                        // Add Inventory
                        Console.WriteLine("Enter Inventory Details:");
                        Console.Write("Product ID: ");
                        int productIDForInventory = int.Parse(Console.ReadLine());
                        Console.Write("Quantity in Stock: ");
                        int quantityInStock = int.Parse(Console.ReadLine());
                        Console.Write("Last Stock Update (yyyy-mm-dd): ");
                        DateTime lastStockUpdate = DateTime.Parse(Console.ReadLine());

                        Inventory inventory = new Inventory
                        {
                            Product = new Product { ProductID = productIDForInventory },
                            QuantityInStock = quantityInStock,
                            LastStockUpdate = lastStockUpdate
                        };
                        serviceProvider.AddInventory(inventory);
                        Console.WriteLine("Inventory Added Successfully!");
                        break;

                    case 9:
                        // Update Inventory
                        Console.Write("Enter Inventory ID to Update: ");
                        int inventoryIDToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Updated Quantity in Stock: ");
                        int updatedQuantityInStock = int.Parse(Console.ReadLine());
                        Console.Write("Updated Last Stock Update (yyyy-mm-dd): ");
                        DateTime updatedStockDate = DateTime.Parse(Console.ReadLine());

                        Inventory updatedInventory = new Inventory
                        {
                            InventoryID = inventoryIDToUpdate,
                            QuantityInStock = updatedQuantityInStock,
                            LastStockUpdate = updatedStockDate
                        };
                        serviceProvider.UpdateInventory(updatedInventory);
                        Console.WriteLine("Inventory Updated Successfully!");
                        break;

                    case 10:
                        // Remove Inventory
                        Console.Write("Enter Inventory ID to Remove: ");
                        int inventoryIDToRemove = int.Parse(Console.ReadLine());
                        serviceProvider.RemoveInventory(inventoryIDToRemove);
                        Console.WriteLine("Inventory Removed Successfully!");
                        break;

                    case 11:
                        // Update Customer Account
                        Console.Write("Enter Customer ID to Update: ");
                        int customerIDToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Updated First Name: ");
                        string updatedFirstName = Console.ReadLine();
                        Console.Write("Updated Last Name: ");
                        string updatedLastName = Console.ReadLine();
                        Console.Write("Updated Email: ");
                        string updatedEmail = Console.ReadLine();
                        Console.Write("Updated Phone: ");
                        string updatedPhone = Console.ReadLine();
                        Console.Write("Updated Address: ");
                        string updatedAddress = Console.ReadLine();

                        Customer updatedCustomer = new Customer
                        {
                            CustomerID = customerIDToUpdate,
                            FirstName = updatedFirstName,
                            LastName = updatedLastName,
                            Email = updatedEmail,
                            Phone = updatedPhone,
                            Address = updatedAddress
                        };
                        serviceProvider.UpdateCustomerAccount(updatedCustomer);
                        Console.WriteLine("Customer Account Updated Successfully!");
                        break;

                    case 12:
                        // Process Payment
                        Console.Write("Enter Order ID to Process Payment: ");
                        int orderIDForPayment = int.Parse(Console.ReadLine());
                        Console.Write("Enter Payment Amount: ");
                        decimal paymentAmount = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Payment Method: ");
                        string paymentMethod = Console.ReadLine();

                        serviceProvider.ProcessPayment(orderIDForPayment, paymentAmount, paymentMethod);
                        Console.WriteLine("Payment Processed Successfully!");
                        break;

                    case 13:
                        // Search Products
                        Console.Write("Enter Search Query: ");
                        string searchQuery = Console.ReadLine();
                        var products = serviceProvider.SearchProducts(searchQuery);
                        Console.WriteLine("Search Results:");
                        foreach (var prod in products)
                        {
                            Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.ProductName}, Price: {prod.Price}");
                        }
                        break;

                    case 14:
                        // Get Recommended Products
                        Console.Write("Enter Customer ID for Recommendations: ");
                        int customerIDForRecommendation = int.Parse(Console.ReadLine());
                        var recommendedProducts = serviceProvider.GetRecommendedProducts(customerIDForRecommendation);
                        Console.WriteLine("Recommended Products:");
                        foreach (var prod in recommendedProducts)
                        {
                            Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.ProductName}, Price: {prod.Price}");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (choice != 0);
        }
    }
}
