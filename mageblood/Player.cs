

public class Player
{
    double CurrentHitPoints;
    double ToMaximumHitPoints;
    double MaxHitPoints;
    double CurrentStrength;
    const double MIN_STRENGTH = 5;
    int MULTIPLICATOR_STRENGTH_TO_HP = 5;
    public Dictionary<Type, Item?> Equipment = new();
    public Inventory inventory = new();

    public Player()
    {
        CurrentStrength = MIN_STRENGTH;
        UpdateStats();
        RestoreRessources();
    }

    public void ShowStats()
    {
        Console.WriteLine("== Player Stats ==");
        Console.WriteLine($"Hitpoints: {CurrentHitPoints}/{MaxHitPoints}");
        Console.WriteLine($"Strength: {CurrentStrength}");

    }

    public Item? EquipItem(Item item)
    {
        Equipment.TryGetValue(item.GetType(), out Item? oldItem);
        Equipment[item.GetType()] = item;
        Console.WriteLine($"Player equiped: {item.name} in Slot: {item.GetType()}");
        if (oldItem is not null) oldItem = inventory.AddItem(oldItem); // Tries to load into Inventory, if Inv is full, next layer has to deal with item
        UpdateStats();
        return oldItem;
    }

    public void RestoreRessources()
    {
        CurrentHitPoints = MaxHitPoints;
    }

    void UpdateStatsFromEquipment(Equpipable item)
    {
        foreach (Stat stat in item.stats)
        {
            if (stat.name == "+# to maximum hitpoints")
            {
                ToMaximumHitPoints += stat.value;
            }
            else if (stat.name == "+# to maximum strength")
            {
                CurrentStrength += stat.value;
            }
        }
    }

    void UpdateStatsFromAllEquipment()
    {
        foreach (Equpipable equipment in Equipment.Values)
        {
            if (equipment is null) continue;
            UpdateStatsFromEquipment(equipment);
        }
    }

    void UpdateStats()
    {
        ResetStats();
        UpdateStatsFromAllEquipment();
        UpdateMaxHitPoints();
    }

    void UpdateMaxHitPoints()
    {
        MaxHitPoints = (CurrentStrength * MULTIPLICATOR_STRENGTH_TO_HP) + ToMaximumHitPoints;
        if (CurrentHitPoints > MaxHitPoints) CurrentHitPoints = MaxHitPoints;
    }

    void ResetStats()
    {
        ToMaximumHitPoints = 0;
        MaxHitPoints = 0;
        CurrentStrength = MIN_STRENGTH;
    }
}