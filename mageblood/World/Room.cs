class Room
{
    private HashSet<WorldHelpers.Directions> Doors;
    private Type RoomType;
    private Activity? Activity;
    public World? EntranceOrigin { get; set; }
    public World? ExitDestination { get; set; }
    public enum Type
    {
        Empty,
        Activity,
        MapEntrance,
        MapExit
    }
    public Dictionary<Type, string> RoomTypeSymbols = new()
    {
        { Type.Empty, "" },
        { Type.Activity, "" }, //TODO -> Continue here
    };

    public Room(Type roomType, HashSet<WorldHelpers.Directions> doors, Activity? activity = null)
    {
        RoomType = roomType;
        Doors = doors;
        if (roomType != Type.Activity && activity is not null || roomType == Type.Activity && activity is null)
            Error.Print(Error.Code.RoomTypeMissMatchActivity);
        Activity = activity;
    }
    public void SetEntranceOrigin(World origin)
    {
        EntranceOrigin = origin;
    }

    public void SetExitDestination(World destination)
    {
        ExitDestination = destination;
    }

    public void ShowRoom()
    {
        Console.Write($""); Console.Write($""); Console.Write($"   \n"); 
        Console.Write($""); Console.Write($""); Console.Write($"   \n");
        Console.Write($""); Console.Write($""); Console.Write($"   \n");
    }
}