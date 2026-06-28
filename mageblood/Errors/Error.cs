public static class Error
{
    public enum Code
    {
        ItemHasTooManyStatsAlready,
        InventoryIsFull
    }

    public enum Level
    {
        Warning,
        Error
    }

    private static readonly Dictionary<Code, (Level level, string message)> Messages = new()
    {
        { Code.ItemHasTooManyStatsAlready, (Level.Warning, "Item has too many stats already.") },
        { Code.InventoryIsFull, (Level.Warning, "Inventory is alread full")}
    };

    public static void Print(Code code)
    {
        (Level level, string message) = Messages[code];
        Console.WriteLine($"{level} - {message}");
    }
}