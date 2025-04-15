using System;
using System.Data.SqlClient;
using TechShopApp.entity;
using TechShopApp.exception;
using TechShopApp.util;
using Microsoft.Data.SqlClient;
namespace TechShopApp.dao
{
    public class ServiceProvider : IServiceProvider
    {
        public void RegisterCustomer(Customer customer)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Customers (Customer_FirstName, Customer_LastName, Customer_Email, Customer_Phone, Address) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Phone, @Address)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Address", customer.Address);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Customer Registered Successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Products (Product_ID, Product_Name, Product_Description, Product_Price) " +
                                      "VALUES (@ProductID, @ProductName, @Description, @Price)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "UPDATE Products SET ProductName = @ProductName, Description = @Description, Price = @Price WHERE ProductID = @ProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void RemoveProduct(int productID)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", productID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        //
        public void PlaceOrder(Order order)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES (@CustomerID, @OrderDate, @TotalAmount)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerID", order.Customer.CustomerID);
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderID", orderDetail.Order.OrderID);
                    command.Parameters.AddWithValue("@ProductID", orderDetail.Product.ProductID);
                    command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        //
        public string GetOrderStatus(int orderID)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "SELECT Status FROM Orders WHERE OrderID = @OrderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader["Status"].ToString();
                    }

                    return "Order not found.";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return "Error retrieving order status.";
                }
            }
        }
        //
        public void AddInventory(Inventory inventory)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Inventory (ProductID, QuantityInStock, LastStockUpdate) VALUES (@ProductID, @QuantityInStock, @LastStockUpdate)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", inventory.Product.ProductID);
                    command.Parameters.AddWithValue("@QuantityInStock", inventory.QuantityInStock);
                    command.Parameters.AddWithValue("@LastStockUpdate", inventory.LastStockUpdate);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void UpdateInventory(Inventory inventory)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "UPDATE Inventory SET QuantityInStock = @QuantityInStock, LastStockUpdate = @LastStockUpdate WHERE InventoryID = @InventoryID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
                    command.Parameters.AddWithValue("@QuantityInStock", inventory.QuantityInStock);
                    command.Parameters.AddWithValue("@LastStockUpdate", inventory.LastStockUpdate);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void RemoveInventory(int inventoryID)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM Inventory WHERE InventoryID = @InventoryID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@InventoryID", inventoryID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        //
        //public List<SalesReport> GenerateSalesReport(DateTime startDate, DateTime endDate)
        //{
        //    List<SalesReport> reports = new List<SalesReport>();

        //    using (SqlConnection connection = DatabaseConnector.OpenConnection())
        //    {
        //        try
        //        {
        //            string query = "SELECT ProductID, SUM(Quantity) AS TotalQuantity, SUM(TotalAmount) AS TotalSales FROM Orders WHERE OrderDate BETWEEN @StartDate AND @EndDate GROUP BY ProductID";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@StartDate", startDate);
        //            command.Parameters.AddWithValue("@EndDate", endDate);

        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                SalesReport report = new SalesReport
        //                {
        //                    ProductID = Convert.ToInt32(reader["ProductID"]),
        //                    TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
        //                    TotalSales = Convert.ToDecimal(reader["TotalSales"])
        //                };
        //                reports.Add(report);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error: {ex.Message}");
        //        }
        //    }

        //    return reports;
        //}
        public void UpdateCustomerAccount(Customer customer)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Address", customer.Address);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        //
        public void ProcessPayment(int orderID, decimal amount, string paymentMethod)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    // Step 1: Insert Payment Details
                    string paymentQuery = "INSERT INTO Payments (OrderID, Amount, PaymentMethod, PaymentDate) VALUES (@OrderID, @Amount, @PaymentMethod, @PaymentDate)";
                    SqlCommand paymentCommand = new SqlCommand(paymentQuery, connection);
                    paymentCommand.Parameters.AddWithValue("@OrderID", orderID);
                    paymentCommand.Parameters.AddWithValue("@Amount", amount);
                    paymentCommand.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    paymentCommand.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                    paymentCommand.ExecuteNonQuery();

                    // Step 2: Update Order Status to "Paid"
                    string orderStatusQuery = "UPDATE Orders SET Status = 'Paid' WHERE OrderID = @OrderID";
                    SqlCommand orderStatusCommand = new SqlCommand(orderStatusQuery, connection);
                    orderStatusCommand.Parameters.AddWithValue("@OrderID", orderID);
                    orderStatusCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        //
        public List<Product> SearchProducts(string searchQuery)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "SELECT ProductID, ProductName, Description, Price FROM Products WHERE ProductName LIKE @SearchQuery OR Description LIKE @SearchQuery";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int productID = Convert.ToInt32(reader["ProductID"]);
                        string productName = reader["ProductName"].ToString();
                        string description = reader["Description"].ToString();
                        decimal price = Convert.ToDecimal(reader["Price"]);

                        Product product = new Product(productID, productName, description, price);
                        products.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return products;
        }

        public List<Product> GetRecommendedProducts(int customerID)
        {
            List<Product> recommendedProducts = new List<Product>();

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "SELECT DISTINCT p.ProductID, p.ProductName, p.Description, p.Price FROM Products p INNER JOIN OrderDetails od ON p.ProductID = od.ProductID INNER JOIN Orders o ON o.OrderID = od.OrderID WHERE o.CustomerID = @CustomerID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Using the parameterized constructor to create a Product object
                        Product product = new Product(
                            Convert.ToInt32(reader["ProductID"]),
                            reader["ProductName"].ToString(),
                            reader["Description"].ToString(),
                            Convert.ToDecimal(reader["Price"])
                        );
                        recommendedProducts.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return recommendedProducts;
        }



    }
}