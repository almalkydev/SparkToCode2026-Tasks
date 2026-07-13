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
