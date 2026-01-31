using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Order 1 (USA)
            Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("Alice Johnson", address1);
            Order order1 = new Order(customer1);
            
            order1.AddProduct(new Product("Wireless Mouse", "M001", 29.99, 1));
            order1.AddProduct(new Product("Mouse Pad", "P055", 12.50, 2));

            // Order 2 (International)
            Address address2 = new Address("789 Rue de Lyon", "Paris", "IDF", "France");
            Customer customer2 = new Customer("Jean Dupont", address2);
            Order order2 = new Order(customer2);
            
            order2.AddProduct(new Product("Mechanical Keyboard", "K800", 115.00, 1));
            order2.AddProduct(new Product("USB-C Cable", "C22", 15.00, 3));
            order2.AddProduct(new Product("Webcam", "W99", 85.00, 1));

            // Display Results for Order 1
            Console.WriteLine("==================================");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Order Price: ${order1.CalculateTotalCost():0.00}");
            Console.WriteLine("==================================");

            // Display Results for Order 2
            Console.WriteLine("\n==================================");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Order Price: ${order2.CalculateTotalCost():0.00}");
            Console.WriteLine("==================================");
        }
    }
}