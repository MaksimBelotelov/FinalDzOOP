public class MainMenu : Menu
{
    UserController userController;
    public MainMenu() : base("Добро пожаловать в первый оффлайн-банк.\n\nГлавное меню: ")
    {
        userController = new UserController();

        menuItems.Add(new MenuRegister(userController));
        menuItems.Add(new MenuSignIn(userController));
        menuItems.Add(new MenuExit(userController, null));        
    }
}