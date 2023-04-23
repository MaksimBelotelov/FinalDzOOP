public class UserController
{
    private List<User> userList;
    private UserRepo userRepo;

    public UserController()
    {
        this.userRepo = new UserRepo();
        this.userList = userRepo.LoadUsersFromBase();
    }

    public List<User> GetUserList()
    {
        return userList;
    }

// Регистрация нового пользователя

    public void AddNewUser()
    {
        Console.Write("Введите фамилию: ");
        string surname = NotEmptyLettersOnlyInput();
        Console.Write("Введите имя: ");
        string name = NotEmptyLettersOnlyInput();
        Console.Write("Введите e-mail: ");
        string email;
        do
        {
            email = Console.ReadLine();
        } 
        while(!ValidateEmail(email));
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();

        userList.Add(new User(surname, name, email, password, new List<int>()));
    }

// Вход

    public User LoginUser(string login, string password)
    {
        foreach(var user in userList)
            if(user.GetEmail().Equals(login))
                if(user.GetPassword().Equals(password))
                    return user;
        return null;
    }

    public void RemoveUser(User user)
    {
        userList.Remove(user);
    }

    public User WhoIsOwner(Account account)
    {
        foreach(var user in userList)
        {
            if(user.GetAccountIds().Contains(account.GetId()))
                return user;
        }
        return null;
    }

    public static string NotEmptyLettersOnlyInput()
    {
        string inpString = Console.ReadLine();
        while(!inpString.Any(c=>char.IsLetter(c)))
        {
            Console.WriteLine("Строка не может быть пустой и должна содержать только буквы.");
            inpString = Console.ReadLine();
        }
        return inpString;
    }

    public bool ValidateEmail(string email)
    {
        foreach(User user in userList)
        {
            if(user.GetEmail().Equals(email))
            {
                Console.WriteLine("Такой email уже зарегистрирован\nВведите другой: ");
                return false;
            }
        }
        return true;
    }

    public void SaveUsersAndExit()
    {
        userRepo.SaveUsersToBase(userList);
    }
}