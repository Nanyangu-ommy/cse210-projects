using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("Area 23", "Midrand", "Lilongwe", "Malawi");
        Customer customer1 = new Customer("Jonathan Nanseta", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25, 2));

        
        Address address2 = new Address("Area 43", "Newlines", "Lilongwe", "Malawi");
        Customer customer2 = new Customer("Lisa Nanseta", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "P003", 600, 1));
        order2.AddProduct(new Product("Charger", "P004", 20, 3));

        
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}
