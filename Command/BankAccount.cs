﻿namespace Command;

public class BankAccount
{
    private int balance;
    private int overdraftLimit = -500;

    public void Deposit(int amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited ${amount}, balance = {balance}");
    }

    public bool Withdraw(int amount)
    {
        if (balance - amount >= overdraftLimit)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew ${amount}, balance = {balance}");
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{nameof(balance)}: {balance}";
    }
}

public interface ICommand
{
    void Call();
    void Undo();
}

public class BankAccountCommand : ICommand
{
    private BankAccount account;

    public enum Action
    {
        Deposit, Withdraw
    }

    private Action action;
    private int amount;
    private bool succeeded;

    public BankAccountCommand(BankAccount account, Action action, int amount)
    {
        this.account = account;
        this.action = action;
        this.amount = amount;
    }

    public void Call()
    {
        switch (action)
        {
            case Action.Deposit:
                account.Deposit(amount);
                succeeded = true;
                break;
            case Action.Withdraw:
                account.Withdraw(amount);
                succeeded = account.Withdraw(amount);
                break;
        }
    }

    public void Undo()
    {
        if (!succeeded) return;
        switch (action)
        {
            case Action.Deposit:
                account.Withdraw(amount);
                break;
            case Action.Withdraw:
                account.Deposit(amount);
                break;
        }
    }
}
