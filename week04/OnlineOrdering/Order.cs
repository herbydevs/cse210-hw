using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalCost()
        {
            double totalProductCost = 0;
            foreach (Product product in _products)
            {
                totalProductCost += product.CalculateProductTotal();
            }

            double shippingCost = _customer.LivesInUsa() ? 5 : 35;

            return totalProductCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in _products)
            {
                label += $"- {product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "Shipping Label:\n";
            label += $"{_customer.GetName()}\n";
            label += _customer.GetAddress().GetAddressString();
            return label;
        }
    }
}