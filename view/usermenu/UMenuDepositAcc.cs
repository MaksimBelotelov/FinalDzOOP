public class UMenuDepositAcc : MenuItem
{    
    private AccountController accountController;
    private User currentUser;
    
    public UMenuDepositAcc(User currentUser, AccountController accountController) : base("Пополнить счёт")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
    }
    
    public override void ProcessItem()
    {
        Account currentAcc = accountController.FindAccountByNumber();
        if((currentAcc != null) && (currentAcc.IsMyAccount(currentUser)))
        {
            Console.Write("Введите сумму для пополнения: ");
            double amountToDeposit = Convert.ToDouble(Console.ReadLine());
            if(amountToDeposit > 0)
            {
                currentAcc.SetBalance(currentAcc.GetBalance() + amountToDeposit);
                Console.WriteLine("\nСчет № " + currentAcc.GetId() + " пополнен." + 
                                "\nНовый баланс: " + currentAcc.GetBalance() + "\n");
            }
            else
                Console.WriteLine("Нельзя пополнить отрицательной суммой");
        }
        else
            Console.WriteLine("Счет не найден");
    }
}