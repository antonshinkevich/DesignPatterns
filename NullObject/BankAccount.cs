namespace NullObject;

public interface ILog
{
    void Info(string message);
    void Warn(string message);
}

class ConsoleLog : ILog
{
    public void Info(string message)
    {
        Console.WriteLine(message);
    }

    public void Warn(string message)
    {
        Console.WriteLine("WARNING: " + message);
    }
}

class OptionalLog : ILog
{
    private ILog impl;

    public OptionalLog(ILog impl)
    {
        this.impl = impl;
    }

    public void Info(string message)
    {
        impl?.Info(message);
    }

    public void Warn(string message)
    {
        impl?.Warn(message);
    }
}

public sealed class NullLog : ILog
{
    public void Info(string message)
    {
        
    }

    public void Warn(string message)
    {
        
    }
}

public class BankAccount
{
    private ILog log;
    private int balance;

    public BankAccount(ILog log = null)
    {
        this.log = new OptionalLog(log);
    }

    public void Deposit(int amount)
    {
        balance += amount;
        // check for null
        log?.Info($"Deposited ${amount}, balance is now {balance}");
    }

    public void Withdraw(int amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            log?.Info($"Withdrew ${amount}, we have ${balance} left");
        }
        else
        {
            log?.Warn($"Could not withdraw ${amount} because " +
                      $"balance is only ${balance}");
        }
    }
}
