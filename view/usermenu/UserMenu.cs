public class UserMenu : Menu
{
    AccountController accountController;
    UserController usercontroller;

    public UserMenu(User user, UserController userController) : base("Меню пользователя")
    {
        accountController = new AccountController();
        this.usercontroller = userController;

        menuItems.Add(new UMenuOpenAcc(user, accountController));
        menuItems.Add(new UMenuShowAccs(user, accountController));
        menuItems.Add(new UMenuDepositAcc(user, accountController));
        menuItems.Add(new UMenuOffAcc(user, accountController));
        menuItems.Add(new UMenuTransfer(user, accountController));
        menuItems.Add(new UMenuCloseAcc(user, accountController));
        menuItems.Add(new UMenuDelUser(user, accountController, userController));
        menuItems.Add(new MenuExit(userController, accountController));
    }
}