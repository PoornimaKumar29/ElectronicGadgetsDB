using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechShopApp.entity
{
    public class Product
    {
        // Private fields
        private int productID;
        private string productName;
        private string description;
        private decimal price;
        public Product()
        {
            // Set default values or leave empty
        }

        // Constructor
        public Product(int productID, string productName, string description, decimal price)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
        }

        // Properties
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                // Validation: ProductName must not be null or empty
                if (!string.IsNullOrWhiteSpace(value))
                {
                    productName = value;
                }
                else
                {
                    Console.WriteLine("Product Name cannot be null or empty.");
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                // Validation: Description must not be null or empty
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
                else
                {
                    Console.WriteLine("Description cannot be null or empty.");
                }
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                // Validation: Price must be non-negative
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Price must be a non-negative value.");
                }
            }
        }
    }
}
