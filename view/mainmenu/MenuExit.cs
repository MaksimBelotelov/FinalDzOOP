public class MenuExit : MenuItem
{    
    private UserController userController;
    private AccountController accountController;

    public MenuExit(UserController userController, AccountController accountController) : base("Выход")
    {
        this.userController = userController;
        this.accountController = accountController;
    }

    public override void ProcessItem()
    {
        userController.SaveUsersAndExit();
        if(accountController != null) accountController.SaveAccountAndExit();
        Console.WriteLine("До свидания!");
        Environment.Exit(0);
    }
}