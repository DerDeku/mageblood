public static class Error
{
    public enum Code
    {
        ItemHasTooManyStatsAlready,
        InventoryIsFull,
        WorldAlreadyHasMapAtCoordinates,
        MapAlreadyHasRoomAtCoordinates,
        RoomTypeMissMatchActivity
    }

    public enum Level
    {
        Warning,
        Error
    }

    private static readonly Dictionary<Code, (Level level, string message)> Messages = new()
    {
        { Code.ItemHasTooManyStatsAlready, (Level.Warning, "Item has too many stats already.") },
        { Code.InventoryIsFull, (Level.Warning, "Inventory is alread full") },
        { Code.WorldAlreadyHasMapAtCoordinates, (Level.Warning, "Cannot add map: a map already exists at the specified coordinates.")},
        { Code.MapAlreadyHasRoomAtCoordinates, (Level.Warning, "Cannot add room: a room already exists at the specified coordinates.")},
        { Code.RoomTypeMissMatchActivity, (Level.Warning, "Room type does not match set activity")},
    };

    public static void Print(Code code)
    {
        (Level level, string message) = Messages[code];
        Console.WriteLine($"{level} - {message}");
    }
}