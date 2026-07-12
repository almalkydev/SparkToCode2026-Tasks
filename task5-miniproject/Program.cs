using System;
using System.Collections.Generic;

namespace BankingSystemApp
{
    internal class Program
    {
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();

        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("Welcome to Spark Bank ");
                Console.WriteLine("1.Add New Account");
                Console.WriteLine("2.Deposit Money");
                Console.WriteLine("3.Withdraw Money");
                Console.WriteLine("4.Show Balance");
                Console.WriteLine("5.Transfer Amount");
                Console.WriteLine("6.List All Accounts");
                Console.WriteLine("7.Find Richest Customer");
                Console.WriteLine("8.Exit");
                Console.Write("Choose an option: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; // skip the rest of this loop pass show the menu again
                }

                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        ListAllAccounts();
                        break;
                    case 7:
                        FindRichestCustomer();
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }

        static void AddAccount()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new account number: ");
            string accNumber = Console.ReadLine();

            // make sure this account number isn't already taken
            if (accountNumbers.Contains(accNumber))
            {
                Console.WriteLine("Error: An account with this number already exists.");
                return;
            }

            Console.Write("Enter initial deposit amount: ");
            double startingBalance;
            try
            {
                startingBalance = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (startingBalance < 0)
            {
                Console.WriteLine("Error: Initial deposit cannot be negative.");
                return;
            }

            // All three lists get updated together so they stay the same length
            customerNames.Add(name);
            accountNumbers.Add(accNumber);
            balances.Add(startingBalance);

            Console.WriteLine($"Account created successfully! Name: {name}, Account: {accNumber}, Balance: {startingBalance:F2}");
        }

        static void DepositMoney()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNumber);
            if (index == -1)
            {
                Console.WriteLine("Error: Account not found.");
                return;
            }

            Console.Write("Enter deposit amount: ");
            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit amount must be positive.");
                return;
            }

            balances[index] += amount;
            Console.WriteLine($"Deposit successful. New balance for {customerNames[index]}: {balances[index]:F2}");
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNumber);
            if (index == -1)
            {
                Console.WriteLine("Error: Account not found.");
                return;
            }

            Console.Write("Enter withdrawal amount: ");
            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal amount must be positive.");
                return;
            }

            if (amount > balances[index])
            {
                Console.WriteLine("Error: Insufficient balance for this withdrawal.");
                return;
            }

            balances[index] -= amount;
            Console.WriteLine($"Withdrawal successful. New balance for {customerNames[index]}: {balances[index]:F2}");
        }

        static void ShowBalance()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNumber);
            if (index == -1)
            {
                Console.WriteLine("Error: Account not found.");
                return;
            }

            Console.WriteLine($"Name: {customerNames[index]}, Account: {accountNumbers[index]}, Balance: {balances[index]:F2}");
        }

        static void TransferAmount()
        {
            Console.Write("Enter sender's account number: ");
            string fromAcc = Console.ReadLine();

            Console.Write("Enter receiver's account number: ");
            string toAcc = Console.ReadLine();

            int fromIndex = accountNumbers.IndexOf(fromAcc);
            int toIndex = accountNumbers.IndexOf(toAcc);

            if (fromIndex == -1 || toIndex == -1)
            {
                Console.WriteLine("Error: One or both account numbers do not exist.");
                return;
            }

            Console.Write("Enter transfer amount: ");
            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Transfer amount must be positive.");
                return;
            }

            if (amount > balances[fromIndex])
            {
                Console.WriteLine("Error: Sender has insufficient balance.");
                return;
            }

            balances[fromIndex] -= amount;
            balances[toIndex] += amount;

            Console.WriteLine("Transfer successful!");
            Console.WriteLine($"{customerNames[fromIndex]}'s new balance: {balances[fromIndex]:F2}");
            Console.WriteLine($"{customerNames[toIndex]}'s new balance: {balances[toIndex]:F2}");
        }
        static void ListAllAccounts()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            Console.WriteLine("All Accounts ");
            for (int i = 0; i < customerNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {customerNames[i]}, Account: {accountNumbers[i]}, Balance: {balances[i]:F2}");
            }
        }


        static void FindRichestCustomer()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            int richestIndex = 0;
            for (int i = 1; i < balances.Count; i++)
            {
                if (balances[i] > balances[richestIndex])
                {
                    richestIndex = i;
                }
            }

            Console.WriteLine($"Richest customer: {customerNames[richestIndex]}, Account: {accountNumbers[richestIndex]}, Balance: {balances[richestIndex]:F2}");
        }
    }
}