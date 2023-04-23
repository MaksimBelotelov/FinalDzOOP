using System.Collections.Generic;

public abstract class Menu 
{
    private string title;
    protected List<MenuItem> menuItems;
    
    public Menu(string title)
    {
        this.title = title;
        this.menuItems = new List<MenuItem>();
    }

    public void MenuStart()
    {
        Console.Clear();
        Console.WriteLine(title);
        
        while(true)
        {
            for(int i = 0; i < menuItems.Count(); i++)
                Console.WriteLine(i + ". " + menuItems[i].GetItemName());
            int choice =-1;
            try{
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException){}
            
            if((choice < menuItems.Count()) && (choice >= 0))
                menuItems[choice].ProcessItem();
            else
                Console.WriteLine("Incorrect input! Необходимо вести цифру от 0 до " + (menuItems.Count() - 1) + "\n");
            if(menuItems[choice].GetItemName() == "Удалить учетную запись") break;
        }
    }
}