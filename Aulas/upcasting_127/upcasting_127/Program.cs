using upcasting_127.Entities;

Account acc = new Account(1001, "Alex", 0.0);
BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

//upcasting
Account acc1 = bacc;
Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
Account acc3 = new SavingsAccount(1004, "Anna", 0.0, 0.01);

//downcasting (operação insegura... testar se realmente é do tipo)
//BusinessAccount acc4 = (BusinessAccount) acc2;
BusinessAccount acc4 = acc2 as BusinessAccount;
acc4.Loan(100.0);

//BusinessAccount acc5 = (BusinessAccount) acc3;
if (acc3 is BusinessAccount)
{
    //BusinessAccount acc5 = (BusinessAccount) acc3;
    BusinessAccount acc5 = acc3 as BusinessAccount;
    acc5.Loan(200.0);
    Console.WriteLine("Loan!");
}

if (acc3 is SavingsAccount)
{
    //SavingsAccount acc5 = (SavingsAccount) acc3;
    SavingsAccount acc5 = acc3 as SavingsAccount;
    acc5.UpdateBalance();
    Console.WriteLine("Update balance!");
}