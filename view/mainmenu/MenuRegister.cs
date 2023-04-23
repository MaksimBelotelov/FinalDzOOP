public class MenuRegister : MenuItem
{    
    private UserController userController;
    
    public MenuRegister(UserController userController) : base("Регистрация")
    {
        this.userController = userController;
    }
    
    public override void ProcessItem()
    {
        userController.AddNewUser();
        Console.WriteLine("Спасибо за регистрацию!\n" + 
                "Теперь вы можете войти, используя e-mail и пароль");
    }
}