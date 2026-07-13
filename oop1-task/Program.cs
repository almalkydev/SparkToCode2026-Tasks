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

    static void ShowMenu()
    {
        Console.WriteLine("1. View Account Details");
        Console.WriteLine("2. Update Student Address");
        Console.WriteLine("3. Make a Deposit");
        Console.WriteLine("4. Make a Withdrawal");
        Console.WriteLine("5. View Product Details");
        Console.WriteLine("6. Register a Student");
        Console.WriteLine("7. Compare Two Account Balances");
        Console.WriteLine("8. Restock Product & Stock Level Check");
        Console.WriteLine("9. Transfer Between Accounts");
        Console.WriteLine("10. Update Student Grade");
        Console.WriteLine("11. Student Report Card");
        Console.WriteLine("12. Account Health Status");
        Console.WriteLine("13. Bulk Sale With Revenue Calculation");
        Console.WriteLine("14. Scholarship Eligibility Check");
        Console.WriteLine("15. Full Balance Top-Up Flow");
        Console.WriteLine("16. Quick Account Opening");
        Console.WriteLine("17. Total Students Counter");
        Console.WriteLine("18. Overdrawn Account Check");
        Console.WriteLine("19. Set Student Security PIN");
        Console.WriteLine("20. Exit");
        Console.Write("Choose an option: ");
    }

    static BankAccount PickAccount()
    {
        Console.WriteLine("1) " + account1.HolderName + "  2) " + account2.HolderName);
        Console.Write("Choose account: ");
        string input = Console.ReadLine();
        if (input == "1") return account1;
        return account2;
    }

    static Student PickStudent()
    {
        Console.WriteLine("1) " + student1.Name + "  2) " + student2.Name);
        Console.Write("Choose student: ");
        string input = Console.ReadLine();
        if (input == "1") return student1;
        return student2;
    }

    static Product PickProduct()
    {
        Console.WriteLine("1) " + product1.ProductName + "  2) " + product2.ProductName);
        Console.Write("Choose product: ");
        string input = Console.ReadLine();
        if (input == "1") return product1;
        return product2;
    }

    static void Case1()
    {
        BankAccount acc = PickAccount();
        acc.CheckBalance();
    }

    static void Case2()
    {
        Student s = PickStudent();
        Console.Write("Enter new address: ");
        string newAddress = Console.ReadLine();
        s.Address = newAddress;
        Console.WriteLine("Address updated to " + newAddress);
    }

    static void Case3()
    {
        BankAccount acc = PickAccount();
        Console.Write("Enter deposit amount: ");
        double amount;
        if (double.TryParse(Console.ReadLine(), out amount))
        {
            acc.Deposit(amount);
            Console.WriteLine(acc.HolderName + "'s new balance: " + acc.Balance);
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void Case4()
    {
        BankAccount acc = PickAccount();
        Console.Write("Enter withdrawal amount: ");
        double amount;
        if (double.TryParse(Console.ReadLine(), out amount))
        {
            acc.Withdraw(amount);
            Console.WriteLine("Balance: " + acc.Balance);
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void Case5()
    {
        Product p = PickProduct();
        double value = p.GetInventoryValue();
        Console.WriteLine("Total inventory value: " + value);
    }

    static void Case6()
    {
        Student s = PickStudent();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        s.Register(email);
        Console.WriteLine(s.Name + " has been successfully registered.");
    }

    static void Case7()
    {
        if (account1.Balance > account2.Balance)
            Console.WriteLine(account1.HolderName + " has more money.");
        else if (account2.Balance > account1.Balance)
            Console.WriteLine(account2.HolderName + " has more money.");
        else
            Console.WriteLine("Both accounts have equal balance.");
    }

    static void Case8()
    {
        Product p = PickProduct();
        Console.Write("Enter quantity to restock: ");
        int qty;
        if (int.TryParse(Console.ReadLine(), out qty))
        {
            p.Restock(qty);
            if (p.StockQuantity < 10)
                Console.WriteLine("Stock level: Low");
            else if (p.StockQuantity < 50)
                Console.WriteLine("Stock level: Moderate");
            else
                Console.WriteLine("Stock level: Well Stocked");
        }
        else
        {
            Console.WriteLine("Invalid quantity.");
        }
    }

    static void Case9()
    {
        Console.WriteLine("Source account:");
        BankAccount source = PickAccount();
        Console.WriteLine("Destination account:");
        BankAccount destination = PickAccount();
        Console.Write("Enter amount to transfer: ");
        double amount;
        if (!double.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        if (source.Balance >= amount)
        {
            source.Withdraw(amount);
            destination.Deposit(amount);
            Console.WriteLine("Transfer successful.");
        }
        else
        {
            Console.WriteLine("Transfer failed: not enough balance in source account.");
        }
    }

    static void Case10()
    {
        Student s = PickStudent();
        Console.Write("Enter new grade: ");
        int grade;
        if (!int.TryParse(Console.ReadLine(), out grade))
        {
            Console.WriteLine("Invalid input: grade must be a number.");
            return;
        }

        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade: must be between 0 and 100.");
            return;
        }

        s.Grade = grade;
        Console.WriteLine("Grade updated to " + grade);
    }

    static void Case11()
    {
        Student s = PickStudent();
        string status = s.Grade >= 60 ? "Pass" : "Fail";
        Console.WriteLine("Name: " + s.Name);
        Console.WriteLine("Address: " + s.Address);
        Console.WriteLine("Grade: " + s.Grade);
        Console.WriteLine("Status: " + status);
    }

    static void Case12()
    {
        BankAccount acc = PickAccount();
        string status;
        if (acc.Balance < 50)
            status = "Low Balance";
        else if (acc.Balance <= 1000)
            status = "Healthy";
        else
            status = "Premium";

        Console.WriteLine("Status: " + status);
    }

    static void Case13()
    {
        Product p = PickProduct();
        Console.Write("Enter quantity to sell: ");
        int qty;
        if (!int.TryParse(Console.ReadLine(), out qty))
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        if (qty > p.StockQuantity)
        {
            int needed = qty - p.StockQuantity;
            Console.WriteLine("Not enough stock. You need " + needed + " more units.");
        }
        else
        {
            p.Sell(qty);
            double revenue = qty * p.Price;
            Console.WriteLine("Sale complete. Revenue: " + revenue);
        }
    }
