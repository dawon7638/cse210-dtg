using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Tyler",
            "Texas",
            "USA"
        );

        Customer customer1 = new Customer(
            "James Smith",
            address1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product(
            "Wireless Mouse",
            "WM100",
            25.99,
            2
        ));

        order1.AddProduct(new Product(
            "Mechanical Keyboard",
            "MK200",
            79.99,
            1
        ));

        order1.AddProduct(new Product(
            "USB-C Cable",
            "UC300",
            12.50,
            2
        ));


        Address address2 = new Address(
            "45 King Street",
            "Toronto",
            "Ontario",
            "Canada"
        );

        Customer customer2 = new Customer(
            "Sarah Johnson",
            address2
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product(
            "Laptop Stand",
            "LS400",
            39.99,
            1
        ));

        order2.AddProduct(new Product(
            "Webcam",
            "WC500",
            59.99,
            2
        ));


        List<Order> orders = new List<Order>
        {
            order1,
            order2
        };


        foreach (Order order in orders)
        {
            Console.WriteLine("PACKING LABEL");
            Console.WriteLine("-------------");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("SHIPPING LABEL");
            Console.WriteLine("--------------");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.CalculateTotal():F2}");

            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine();
        }
    }
}