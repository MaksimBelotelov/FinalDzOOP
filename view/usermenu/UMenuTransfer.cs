public class UMenuTransfer : MenuItem
{    
    private AccountController accountController;
    private User currentUser;
    
    public UMenuTransfer(User currentUser, AccountController accountController) : base("Перевести")
    {
        this.accountController = accountController;
        this.currentUser = currentUser;
    }
    
    public override void ProcessItem()
    {
        Console.WriteLine("Счёт для списания");
        Account currentAcc = accountController.FindAccountByNumber();
        if((currentAcc != null) && (currentAcc.IsMyAccount(currentUser)))
        {
            Console.Write("Введите сумму для списания: ");
            double amountToOff = Convert.ToDouble(Console.ReadLine());
            if(amountToOff <= currentAcc.GetBalance())
            {
                Console.WriteLine("Cчёт получателя");
                Account recieverAcc = accountController.FindAccountByNumber();

                if(recieverAcc != null)
                {
                    currentAcc.SetBalance(currentAcc.GetBalance() - amountToOff);
                    recieverAcc.SetBalance(recieverAcc.GetBalance() + amountToOff);
                    Console.WriteLine("\nСчет № " + currentAcc.GetId() + " перевод." + 
                                "\nНовый баланс: " + currentAcc.GetBalance() + "\n");
                }
            }
            else
                Console.WriteLine("Не достаточно средств\n");
        }
        else
            Console.WriteLine("Счет не найден");
    }
}