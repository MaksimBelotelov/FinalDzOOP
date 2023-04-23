public class UserRepo
{
    public const string USERPATH = "UsersData.txt";

    public List<User> LoadUsersFromBase()
    {
        List<User> users = new List<User>();
        
        StreamReader file = new StreamReader(USERPATH);
        String email = file.ReadLine();
        while(email != null)
        {
            string surname = file.ReadLine();
            string name = file.ReadLine();
            string password = file.ReadLine();
            string accountsStr = file.ReadLine();
            List<int> accounts = new List<int>();
            if(accountsStr != null && accountsStr.Length != 0)
            {
                string[] accountStrSplitted = accountsStr.Split();
                foreach(string num in accountStrSplitted)
                    accounts.Add(Int32.Parse(num));
            }
            users.Add(new User(surname, name, email, password, accounts));
            email = file.ReadLine();
        }
        file.Close();
        return users;
    }

    public void SaveUsersToBase(List<User> listOfUsers)
    {
        StreamWriter file = new StreamWriter(USERPATH);
        foreach(User user in listOfUsers)
            file.Write(user + "\n");
        file.Close();
    }
}