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

    private void PrintDetails()
    {
        Console.WriteLine(ProductName + " - Price: " + Price + ", Stock: " + StockQuantity);
    }

    private void LogTransaction()
    {
        Console.WriteLine("Transaction logged for " + ProductName);
    }
}

class Program
{
    static BankAccount account1 = new BankAccount();
    static BankAccount account2 = new BankAccount();
    static Student student1 = new Student();
    static Student student2 = new Student();
    static Product product1 = new Product();
    static Product product2 = new Product();
    static BankAccount newAccount = null; // used in Case 16

    static void Main(string[] args)
    {
        account1.AccountNumber = 1163;
        account1.HolderName = "karim";
        account1.Balance = 120;

        account2.AccountNumber = 15203;
        account2.HolderName = "Ali";
        account2.Balance = 63;

        student1.Name = "Ali";
        student1.Address = "Muscat";
        student1.Grade = 65;

        student2.Name = "Ahmed";
        student2.Address = "Muscat";
        student2.Grade = 70;

        product1.ProductName = "Wireless Mouse";
        product1.Price = 5.500;
        product1.StockQuantity = 50;

        product2.ProductName = "Mechanical Keyboard";
        product2.Price = 15.750;
        product2.StockQuantity = 20;

        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": Case1(); break;
                case "2": Case2(); break;
                case "3": Case3(); break;
                case "4": Case4(); break;
                case "5": Case5(); break;
                case "6": Case6(); break;
                case "7": Case7(); break;
                case "8": Case8(); break;
                case "9": Case9(); break;
                case "10": Case10(); break;
                case "11": Case11(); break;
                case "12": Case12(); break;
                case "13": Case13(); break;
                case "14": Case14(); break;
                case "15": Case15(); break;
                case "16": Case16(); break;
                case "17": Case17(); break;
                case "18": Case18(); break;
                case "19": Case19(); break;
                case "20":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
