using System;

class BankAccount
{
    public int AccountNumber;
    public string HolderName;
    public double Balance;

    public BankAccount() { }

    // Case 16 - parameterized constructor
    public BankAccount(int accNum, string holder, double balance)
    {
        AccountNumber = accNum;
        HolderName = holder;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        SendEmail();
    }

    public void Withdraw(double amount)
    {
        if (Balance >= amount)
            Balance -= amount;
        else
            Console.WriteLine("Not enough balance to withdraw.");

        SendEmail();
    }

    public double CheckBalance()
    {
        PrintInformation();
        return Balance;
    }

    private void PrintInformation()
    {
        Console.WriteLine("Holder: " + HolderName + ", Balance: " + Balance);
    }

    private void SendEmail()
    {
        Console.WriteLine("Email sent to " + HolderName);
    }

    // Case 18 - read-only property
    public bool IsOverdrawn
    {
        get { return Balance < 0; }
    }
}

class Student
{
    public int Grade;
    public string Name;
    public string Address;
    private string email;
    int age;

    private static int totalStudents = 0; // Case 17

    private int pin; // Case 19

    public Student()
    {
        totalStudents++;
    }

    public void Register(string Email)
    {
        email = Email;
        SendEmail();
    }

    public static int GetTotalStudents()
    {
        return totalStudents;
    }

    private void SendEmail()
    {
        Console.WriteLine(Name + " has been registered.");
    }

    // Case 19 - write-only property
    public int Pin
    {
        set { pin = value; }
    }
}

class Product
{
    public string ProductName;
    public double Price;
    public int StockQuantity;

    public void Sell(int quantity)
    {
        if (quantity <= StockQuantity)
            StockQuantity -= quantity;
        else
            Console.WriteLine("Not enough stock available.");

        LogTransaction();
    }

    public void Restock(int quantity)
    {
        StockQuantity += quantity;
        LogTransaction();
    }

    public double GetInventoryValue()
    {
        PrintDetails();
        return Price * StockQuantity;
    }
