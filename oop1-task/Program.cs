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
