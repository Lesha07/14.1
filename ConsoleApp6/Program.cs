using System;
public class Account
{
    public string nameAccount { get; private set; }

    private double balanceAccount;

    public double Balance
    {
        get { return balanceAccount; }
    }

    public Account(string name, double initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance cannot be less than 0.");
        }

        nameAccount = name;

        balanceAccount = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Deposit amount cannot be negative.");
        }

        balanceAccount += amount;
    }

    public void Withdrawal(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Withdrawal amount cannot be negative.");
        }

        if (balanceAccount - amount < 0)
        {
            throw new InvalidOperationException("Insufficient funds for this withdrawal.");
        }

        balanceAccount -= amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Account heikkisAccount = new Account("Heikki's account", 100.00);
        Account heikkisSwissAccount = new Account("Heikki's account in Switzerland", 1000000.00);

        heikkisAccount.Withdrawal(20);
        Console.WriteLine("The balance of Heikki's account is now: " + heikkisAccount.Balance);

        heikkisSwissAccount.Deposit(200);
        Console.WriteLine("The balance of Heikki's other account is now: " + heikkisSwissAccount.Balance);
    }
}
