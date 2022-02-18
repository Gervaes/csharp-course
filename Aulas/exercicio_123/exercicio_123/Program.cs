using System.Globalization;
using exercicio_123.Entities;
using exercicio_123.Entities.Enums;

Console.WriteLine("Enter client data:");
Console.Write("Name: ");
string name = Console.ReadLine();
Console.Write("Email: ");
string email = Console.ReadLine();
Console.Write("Birth date (DD/MM/YYYY): ");
DateTime bDate = DateTime.Parse(Console.ReadLine());

Client client = new Client(name, email, bDate);

Console.WriteLine("Enter order data: ");
Console.Write("Status: ");
OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
Console.Write("How many items to this order? ");
int quantity = int.Parse(Console.ReadLine());

Order order = new Order(client, status);

for (int i = 0; i < quantity; i++) {
    Console.WriteLine($"Enter #{i+1} item data: ");
    Console.Write("Product name: ");
    string productName = Console.ReadLine();
    Console.Write("Product price: ");
    double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Quantity: ");
    int productQuantity = int.Parse(Console.ReadLine());

    Product product = new Product(productName, productPrice);
    OrderItem item = new OrderItem(productQuantity, productPrice, product);
    order.AddItem(item);
}

Console.WriteLine();
Console.WriteLine($"Order moment: {order.Moment}");
Console.WriteLine($"Order status: {order.status}");
Console.WriteLine($"Client: {order.Client}");
Console.WriteLine("Order Items:");
foreach (OrderItem item in order.Items) {
    Console.WriteLine(item);
}
Console.WriteLine($"Total price: ${order.Total().ToString("F2", CultureInfo.InvariantCulture)}");
