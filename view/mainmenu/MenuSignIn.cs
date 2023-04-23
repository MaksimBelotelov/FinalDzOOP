public class MenuSignIn : MenuItem
{   
    private UserController userController;

    public MenuSignIn(UserController userController) : base("Вход")
    {
        this.userController = userController;
    }
    
    public override void ProcessItem()
    {
        Console.Write("Введите ваш e-mail: ");
        string email = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();
        User currentUser = userController.LoginUser(email, password);
        if(currentUser != null)
        {
            UserMenu userMenu = new UserMenu(currentUser, userController);
            userMenu.MenuStart();
        }
        else
        {
            Console.WriteLine("Не удалось войти.\n Пользователь не найден или ошибка в пароле.");
        }
    }
}