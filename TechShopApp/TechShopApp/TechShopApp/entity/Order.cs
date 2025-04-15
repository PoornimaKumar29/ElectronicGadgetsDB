using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.entity
{
    public class Order
    {
        // Private fields
        private int orderID;
        private Customer customer;  // Composition (one-to-one relationship with Customer)
        private DateTime orderDate;
        private decimal totalAmount;

        public Order() { }
        // Constructor
        public Order(int orderID, Customer customer, DateTime orderDate, decimal totalAmount)
        {
            this.OrderID = orderID;
            this.Customer = customer; // Ensures that customer cannot be null
            this.OrderDate = orderDate;
            this.TotalAmount = totalAmount;
        }

        // Properties
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set
            {
                // Validation: Ensure that the customer is not null
                if (value != null)
                {
                    customer = value;
                }
                else
                {
                    Console.WriteLine("Customer cannot be null.");
                }
            }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                // Validation: Order date cannot be in the future
                if (value <= DateTime.Now)
                {
                    orderDate = value;
                }
                else
                {
                    Console.WriteLine("Order date cannot be in the future.");
                }
            }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set
            {
                // Validation: Total amount cannot be negative
                if (value >= 0)
                {
                    totalAmount = value;
                }
                else
                {
                    Console.WriteLine("Total amount cannot be negative.");
                }
            }
        }
    }
}
