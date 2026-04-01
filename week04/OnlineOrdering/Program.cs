using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    // Product class
    public class Product
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal TotalCost() => Price * Quantity;
    }

    // Address class
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }

        public Address(string street, string city, string stateProvince, string country)
        {
            Street = street;
            City = city;
            StateProvince = stateProvince;
            Country = country;
        }

        public bool IsInUSA() => Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        
        public override string ToString()
        {
            return $"{Street}\n{City}, {StateProvince}\n{Country}";
        }
    }

    // Customer class
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public bool IsInUSA() => Address.IsInUSA();
        
    }

       public class Order
    {
        private List<Product> products;
        private Customer customer;
        private const decimal USA_SHIPPING_COST = 5;
                private const decimal INTERNATIONAL_SHIPPING_COST = 35;

        
        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Calculate total cost of products
        public decimal GetTotalProductCost()
        {
            decimal total = 0;
            foreach (var product in products)
                total += product.TotalCost();
            return total;
        }

        // shipping cost based on customer's country
        private decimal GetShippingCost()
        {
            if (customer.IsInUSA())
                return USA_SHIPPING_COST;
           
            else
                return INTERNATIONAL_SHIPPING_COST;
        }

        // Total order cost including shipping
        public decimal GetTotalCost() => GetTotalProductCost() + GetShippingCost();

        // parking label: list of product names and IDs
        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in products)
                label += $"{product.Name} (ID: {product.ProductId}) x{product.Quantity}\n";
            return label;
        }

        // Shipping label: customer name and address
        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
        }

        // Display order summary
        public void DisplayOrderSummary()
        {
           
            Console.WriteLine(GetPackingLabel());
            Console.WriteLine(GetShippingLabel());
            Console.WriteLine($"Subtotal: ${GetTotalProductCost():F2}");
            Console.WriteLine($"Shipping: ${GetShippingCost():F2}");
            Console.WriteLine($"Total:    ${GetTotalCost():F2}");
            
            Console.WriteLine();
        }
    }

    // Program class to demonstrate usage
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("1 Main Street", "New York", "NY", "USA");
            Address address2 = new Address("88 King St", "Toronto", "ON", "Canada");
            Address address3 = new Address("79 Lumley St", "Freetown", "Western Area", "Sierra Leone");
            Address address4 = new Address("101 Downing St", "London", "England", "UK");

            // Create customers
            Customer customer1 = new Customer("Foday Katta", address1);
            Customer customer2 = new Customer("Jeremy Pyne", address2);
            Customer customer3 = new Customer("Ibrahim Mando", address3);
            Customer customer4 = new Customer("David Moriba", address4);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "A233", 99.99m, 1));
            order1.AddProduct(new Product("desktop Monitor", "B056", 27.50m, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Book", "C889", 20.99m, 3));
            order2.AddProduct(new Product("Pen", "D0142", 2.50m, 10));

            Order order3 = new Order(customer3);
            order3.AddProduct(new Product("chair", "E3415", 799.99m, 1));

            Order order4 = new Order(customer4);
            order4.AddProduct(new Product("School bage", "F6778", 89.99m, 1));

            // Display order summaries
            order1.DisplayOrderSummary();
            order2.DisplayOrderSummary();
            order3.DisplayOrderSummary();
            order4.DisplayOrderSummary();
        }
    }
}