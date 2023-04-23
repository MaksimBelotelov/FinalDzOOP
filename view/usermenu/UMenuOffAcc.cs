public class UMenuOffAcc : MenuItem
{    
    private AccountController accountController;
    private User currentUser;
    
    public UMenuOffAcc(User currentUser, AccountController accountController) : base("Снять со счёта")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
    }
    
    public override void ProcessItem()
    {
        Account currentAcc = accountController.FindAccountByNumber();
        if((currentAcc != null) && (currentAcc.IsMyAccount(currentUser)))
        {
            Console.Write("Введите сумму для списания: ");
            double amountToOff = Convert.ToDouble(Console.ReadLine());
            if(amountToOff <= currentAcc.GetBalance())
            {
                currentAcc.SetBalance(currentAcc.GetBalance() - amountToOff);
                Console.WriteLine("\nСчет № " + currentAcc.GetId() + " снятие." + 
                                "\nНовый баланс: " + currentAcc.GetBalance() + "\n");
            }
            else
                Console.WriteLine("Не достаточно средств");
        }
        else
            Console.WriteLine("Счет не найден");
    }
}