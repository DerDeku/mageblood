public static class Errors
{
    public enum Code
    {
        ItemHasTooManyStatsAlready,
        InventoryIsFull,
        WorldAlreadyHasMapAtCoordinates,
        MapAlreadyHasRoomAtCoordinates,
        RoomTypeDoesNotMatchActivity,
        CoordinatesOutOfBounds,
        MapGenerationFailed,
    }

    public enum Level
    {
        Warning,
        Error
    }

    private static readonly Dictionary<Code, (Level level, string message)> Messages = new()
    {
        { Code.ItemHasTooManyStatsAlready, (Level.Warning, "Item has too many stats already.") },
        { Code.InventoryIsFull, (Level.Warning, "Inventory is already full") },
        { Code.WorldAlreadyHasMapAtCoordinates, (Level.Warning, "Cannot add map: a map already exists at the specified coordinates.")},
        { Code.MapAlreadyHasRoomAtCoordinates, (Level.Warning, "Cannot add room: a room already exists at the specified coordinates.")},
        { Code.RoomTypeDoesNotMatchActivity, (Level.Warning, "Room type does not match set activity.")},
        { Code.CoordinatesOutOfBounds, (Level.Error, "The coordinates are out of bounds!")},
        { Code.MapGenerationFailed, (Level.Error, "Something bad happend during map generation!")},
    };

    public static void Report(Code code)
    {
        if (!Messages.TryGetValue(code, out var error)) { Console.WriteLine($"Error - Unknown error code: {code}"); return; }
        switch (error.level)
        {
            case Level.Warning:
                Console.WriteLine($"{error.level} - {error.message}");
            break;
            
            case Level.Error:
                throw new Exception(error.message);
        }
    }
}