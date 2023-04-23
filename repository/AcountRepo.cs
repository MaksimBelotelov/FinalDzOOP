public class AccountRepo
{

    public const string ACCOUNTSPATH = "AccountsData.txt";

    public void SaveAccountsToBase(List<Account> list)
    {
        StreamWriter file = new StreamWriter(ACCOUNTSPATH);
        file.Write(Account.idCounter + "\n");
        foreach (Account account in list)
        {
            file.Write(value: account);
        }
        file.Flush();
        file.Close();
    }

    public List<Account> LoadAccountsFromBase()
    {
        List<Account> accounts = new List<Account>();

        StreamReader file = new StreamReader(ACCOUNTSPATH);
        Account.idCounter = Int32.Parse(file.ReadLine());
        string id = file.ReadLine();
        while (id != null)
        {
            string balance = file.ReadLine();
            accounts.Add(new Account(Int32.Parse(id), Double.Parse(balance)));
            id = file.ReadLine();
        }
        file.Close();

        return accounts;
    }
}