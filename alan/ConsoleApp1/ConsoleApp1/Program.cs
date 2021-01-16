using System;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var account = new BankAccount("alan", 100);
            Console.WriteLine($"Account {account.Number} is created for {account.Owner} with {account.Balance}");
        }
    }
}
