using System;

class Program
{
    static void Main()
    {
        // ===== Order 1 (USA) =====
        Address address1 = new Address(
            "123 Main St",
            "Seattle",
            "WA",
            "USA"
        );

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "K100", 49.99, 1));
        order1.AddProduct(new Product("Mouse", "M200", 19.50, 2));
        order1.AddProduct(new Product("USB Cable", "U300", 5.25, 3));

        // ===== Order 2 (International) =====
        Address address2 = new Address(
            "Av. Siempre Viva 742",
            "Lima",
            "Lima",
            "Peru"
        );

        Customer customer2 = new Customer("Thiago Alexandre", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N500", 3.75, 5));
        order2.AddProduct(new Product("Pen Pack", "P600", 2.10, 4));

        // ===== Display results =====
        DisplayOrder(order1);
        Console.WriteLine("==================================");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost():0.00}");
    }
}
