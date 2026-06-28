

public class Inventory
{
    const int INVENTORY_SLOTS_NUMBER = 25;
    private List<Item?> inventory;

    public Inventory()
    {
        inventory = new(INVENTORY_SLOTS_NUMBER);
    }


    public Item? AddItem(Item item)
    {
        if (inventory.Count < INVENTORY_SLOTS_NUMBER)
        {
            inventory.Add(item);
            return null;
        }
        Error.Print(Error.Code.InventoryIsFull);
        return item;
    }
}