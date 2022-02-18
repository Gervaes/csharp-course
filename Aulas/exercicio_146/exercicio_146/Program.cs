using System.Globalization;
using exercicio_146.Entities;
using exercicio_146.Entities.Exceptions;

try {
    Console.WriteLine("Enter account data");
    Console.Write("Number: ");
    int number = int.Parse(Console.ReadLine());
    Console.Write("Holder: ");
    string holder = Console.ReadLine();
    Console.Write("Initial balance: ");
    double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Withdraw limit: ");
    double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Account account = new Account(number, holder, initialBalance, withdrawLimit);

    Console.WriteLine();
    Console.Write("Enter amount for withdraw: ");
    double withdrawAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    account.Withdraw(withdrawAmount);
    Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");

} catch (DomainException e) {
    Console.WriteLine($"Error in reservation: {e.Message}");
} catch (FormatException e) {
    Console.WriteLine($"Format error: {e.Message}");
} catch (Exception e) {
    Console.WriteLine($"Unexpected error: {e.Message}");
}