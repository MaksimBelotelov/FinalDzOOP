public class UMenuDelUser : MenuItem
{    
    private AccountController accountController;
    private UserController userController;
    private User currentUser;
    
    public UMenuDelUser(User currentUser, AccountController accountController, UserController userController) : base("Удалить учетную запись")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
        this.userController = userController;
    }
    
    public override void ProcessItem()
    {
        if(currentUser.GetAccountIds().Count() != 0)
            Console.WriteLine("У вас есть не закрытые счета\nДля удаления необходимо сначала закрыть счета.");
        else
        {
            userController.RemoveUser(currentUser);
            userController.SaveUsersAndExit();
            Console.WriteLine("Пользователь " + currentUser.GetSurname() + " удален.");
        }
    }
}