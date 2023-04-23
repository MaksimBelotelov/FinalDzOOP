public class AccountController
{
    private AccountRepo accountRepo;
    private List<Account> accountList;

    public AccountController()
    {
        accountRepo = new AccountRepo();
        accountList = accountRepo.LoadAccountsFromBase();
    }

    public int AddNewAccount()
    {
        Account newAccount = new Account();
        accountList.Add(newAccount);
        return newAccount.GetId();
    }

    public void ShowMyAccounts(User currentUser)
    {
        foreach(var accountNumber in currentUser.GetAccountIds())
        {
            foreach(var account in accountList)
            {
                if(accountNumber == account.GetId())
                {
                    Console.WriteLine("Номер счёта: " + account.GetId());
                    Console.WriteLine("Баланс счёта: " + account.GetBalance() + "\n");
                    break;
                }
            }
        }
    }

    public Account FindAccountByNumber()
    {
        Console.Write("Введите номер счёта: ");
        int numberOfAccount = Convert.ToInt32(Console.ReadLine());

        foreach(var account in accountList)
        {
            if((accountList.Count() > 0) && (account.GetId() == numberOfAccount))
                return account;
        }
        Console.WriteLine("Счёт с таким номером не найден");
        return null;
    }

    public void DeleteAccount(Account account)
    {
        accountList.Remove(account);
    }

    public void SaveAccountAndExit()
    {
        accountRepo.SaveAccountsToBase(accountList);
    }
}

