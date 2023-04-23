public abstract class MenuItem 
{
    protected string itemName;

    public MenuItem(string itemName)
    {
        this.itemName = itemName;
    }
    
    public abstract void ProcessItem();
    public string GetItemName()
    {
        return itemName;
    }
}