using System;
using System.Collections.Generic;

class BankAccount
{
    public string DepositorName { get; private set; }
    public int AccountNumber { get; private set; }
    public string AccountType { get; private set; }
    public double Balance { get; private set; }

    public BankAccount(string name, int accountNumber, string accountType, double initialBalance)
    {
        DepositorName = name;
        AccountNumber = accountNumber;
        AccountType = accountType;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Successfully deposited {amount}. New balance is {Balance}.");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Successfully withdrew {amount}. New balance is {Balance}.");
        }
        else
        {
            Console.WriteLine("Insufficient balance or invalid amount.");
        }
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Account Holder: {DepositorName}");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Type: {AccountType}");
        Console.WriteLine($"Balance: {Balance}");
    }
}

class Program
{
    private static List<BankAccount> accounts = new List<BankAccount>();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter your account number:");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            BankAccount account = FindAccount(accountNumber);

            if (account != null)
            {
                PerformBankingOperations(account);
            }
            else
            {
                Console.WriteLine("Account not found.");
                Console.WriteLine("1) Create a new account");
                Console.WriteLine("2) Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    CreateAccount();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Thank you. Have a great day!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting.");
                    break;
                }
            }
        }
    }

    private static BankAccount FindAccount(int accountNumber)
    {
        foreach (var account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }
        return null;
    }

    private static void CreateAccount()
    {
        Console.WriteLine("Enter your Full name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter account number:");
        int accountNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter account type (Savings/Current):");
        string accountType = Console.ReadLine();

        Console.WriteLine("Enter initial balance:");
        double initialBalance = Convert.ToDouble(Console.ReadLine());

        BankAccount newAccount = new BankAccount(name, accountNumber, accountType, initialBalance);
        accounts.Add(newAccount);

        Console.WriteLine("Account created successfully!");
    }

    private static void PerformBankingOperations(BankAccount account)
    {
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1) Display Account Info");
            Console.WriteLine("2) Deposit");
            Console.WriteLine("3) Withdraw");
            Console.WriteLine("4) Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    account.DisplayAccountInfo();
                    break;
                case 2:
                    Console.WriteLine("Enter amount to deposit:");
                    double depositAmount = Convert.ToDouble(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                case 3:
                    Console.WriteLine("Enter amount to withdraw:");
                    double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the bank. Have a great day!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
