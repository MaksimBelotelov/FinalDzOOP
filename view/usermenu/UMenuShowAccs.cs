public class UMenuShowAccs : MenuItem
{    
    private AccountController accountController;
    private User currentUser;
    
    public UMenuShowAccs(User currentUser, AccountController accountController) : base("Показать мои счета")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
    }
    
    public override void ProcessItem()
    {
        if(currentUser.GetAccountIds().Count() > 0)
        {
            Console.WriteLine("Ваши счета: ");
            accountController.ShowMyAccounts(currentUser);
        }
        else
            Console.WriteLine("У вас нет счетов");
    }
}