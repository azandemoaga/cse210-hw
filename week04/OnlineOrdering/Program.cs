using System;
using System.Collections.Generic;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country == "USA";
    }

    public string GetLabel()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}

class Order
{
    private Customer _customer;
    private List<Product> _products;

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
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }

        // Add shipping cost
        if (_customer.GetAddress().IsInUSA())
        {
            total += 5.00;
        }
        else
        {
            total += 15.00;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} ({product.GetProductId()}) - Qty: {product.GetQuantity()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL\n{_customer.GetName()}\n{_customer.GetAddress().GetLabel()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address address1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "TECH001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "TECH005", 25.50, 2));

        // Order 2: International Customer
        Address address2 = new Address("456 Sakura Rd", "Tokyo", "Tokyo", "Japan");
        Customer customer2 = new Customer("Hanako Sato", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Art Print", "ART88", 45.00, 3));
        order2.AddProduct(new Product("Paint Brushes", "ART12", 12.99, 1));
        order2.AddProduct(new Product("Canvas", "ART05", 20.00, 2));

        // Display Order 1
        Console.WriteLine("--- ORDER 1 ---");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine();

        // Display Order 2
        Console.WriteLine("--- ORDER 2 ---");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
    }
}
