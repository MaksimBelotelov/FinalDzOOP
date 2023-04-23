public class UMenuCloseAcc : MenuItem
{    
    private AccountController accountController;
    private User currentUser;
    
    public UMenuCloseAcc(User currentUser, AccountController accountController) : base("Закрыть счет")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
    }
    
    public override void ProcessItem()
    {
        Account currentAcc = accountController.FindAccountByNumber();
        if((currentAcc != null) && (currentAcc.IsMyAccount(currentUser)))
        {
            if(currentAcc.GetBalance() > 0)
            {
                Console.WriteLine("\nНа счёте есть деньги. Для закрытия необходимо снять их.");
            }
            else
            {
                currentUser.GetAccountIds().Remove(currentAcc.GetId());
                accountController.DeleteAccount(currentAcc);
                Console.WriteLine("Счет №: " + currentAcc.GetId() + " удален.");
            }
        }
        else
            Console.WriteLine("Счет не найден");
    }
}