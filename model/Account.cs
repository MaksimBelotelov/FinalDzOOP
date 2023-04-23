public class Account 
{
    public static int idCounter;
    private int id;
    private double balance;

    public Account(int id, double balance)
    {
        this.id = id;
        this.balance = balance;
    }

    public Account() {
        this.id = idCounter++;
        this.balance = 0.0;
    }

    public int GetId() 
    { 
        return id; 
    }

    public double GetBalance()
    {
        return balance;
    }

    public void SetBalance(double newBalance)
    {
        this.balance = newBalance;
    }

    public bool IsMyAccount(User user)
    {
        return user.GetAccountIds().Contains(this.GetId());
    } 

    public override string ToString()
    {
        return id + "\n" +
                balance + '\n';
    }
}

