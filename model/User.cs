public class User 
{
    private string surname;
    private string name;
    private string email;
    private string password;
    private List<int> accountIds;

    public User(string surname, string name, string email, string password, List<int> accounts)
    {
        this.surname = surname;
        this.name = name;
        this.email = email;
        this.password = password;
        this.accountIds = accounts;
    }

    public string GetSurname()
    {
        return surname;
    }

    public string GetName()
    {
        return name;
    }

    public string GetEmail()
    {
        return email;
    }

    public string GetPassword()
    {
        return password;
    }

    public List<int> GetAccountIds()
    {
        return accountIds;
    }

    public override string ToString()
    {
        return email + '\n' +
                surname + '\n' + 
                name + '\n' +
                password + '\n' +
                String.Join(" ", this.accountIds);
    }
}