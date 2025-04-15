using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechShopApp.entity
{
    public class Inventory
    {
        // Private fields
        private int inventoryID;
        private Product product;              // Composition (one-to-one relationship with Product)
        private int quantityInStock;
        private DateTime lastStockUpdate;
        public Inventory() { }
        // Constructor
        public Inventory(int inventoryID, Product product, int quantityInStock, DateTime lastStockUpdate)
        {
            this.InventoryID = inventoryID;
            this.Product = product; // Assuming product cannot be null
            this.QuantityInStock = quantityInStock;
            this.LastStockUpdate = lastStockUpdate;
        }

        // Properties
        public int InventoryID
        {
            get { return inventoryID; }
            set { inventoryID = value; }
        }

        public Product Product
        {
            get { return product; }
            set
            {
                // Validation: Ensure that the product is not null
                if (value != null)
                {
                    product = value;
                }
                else
                {
                    Console.WriteLine("Product cannot be null.");
                }
            }
        }

        public int QuantityInStock
        {
            get { return quantityInStock; }
            set
            {
                // Validation: Quantity cannot be negative
                if (value >= 0)
                {
                    quantityInStock = value;
                }
                else
                {
                    Console.WriteLine("Quantity in stock cannot be negative.");
                }
            }
        }

        public DateTime LastStockUpdate
        {
            get { return lastStockUpdate; }
            set
            {
                // Validation: Last stock update cannot be in the future
                if (value <= DateTime.Now)
                {
                    lastStockUpdate = value;
                }
                else
                {
                    Console.WriteLine("Stock update date cannot be in the future.");
                }
            }
        }
    }
}
