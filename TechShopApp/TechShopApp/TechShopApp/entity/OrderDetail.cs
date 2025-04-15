using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechShopApp.entity
{
    public class OrderDetail
    {
        // Private fields
        private int orderDetailID;
        private Order order;        // Composition (one-to-one relationship with Order)
        private Product product;    // Composition (one-to-one relationship with Product)
        private int quantity;

        public OrderDetail() { }
        // Constructor
        public OrderDetail(int orderDetailID, Order order, Product product, int quantity)
        {
            this.OrderDetailID = orderDetailID;
            this.Order = order; // Ensures that order cannot be null
            this.Product = product; // Ensures that product cannot be null
            this.Quantity = quantity;
        }

        // Properties
        public int OrderDetailID
        {
            get { return orderDetailID; }
            set { orderDetailID = value; }
        }

        public Order Order
        {
            get { return order; }
            set
            {
                // Validation: Ensure that the order is not null
                if (value != null)
                {
                    order = value;
                }
                else
                {
                    Console.WriteLine("Order cannot be null.");
                }
            }
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

        public int Quantity
        {
            get { return quantity; }
            set
            {
                // Validation: Quantity must be positive
                if (value > 0)
                {
                    quantity = value;
                }
                else
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                }
            }
        }
    }
}
