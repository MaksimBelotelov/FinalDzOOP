public class UMenuOpenAcc : MenuItem
{    
    private AccountController accountController;
    private User currentUser;
    
    public UMenuOpenAcc(User currentUser, AccountController accountController) : base("Открыть новый счёт")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
    }
    
    public override void ProcessItem()
    {
        currentUser.GetAccountIds().Add(accountController.AddNewAccount());
        Console.WriteLine("Вам открыт новый счет\n");
    }
}