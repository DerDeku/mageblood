using Mageblood;

class Room
{
    public Direction Doors;
    private Type RoomType;
    private Activity? Activity;
    public World? EntranceOrigin { get; set; }
    public World? ExitDestination { get; set; }
    public Coordinates Coordinates { get; set; }
    public enum Type
    {
        Empty,
        Activity,
        MapEntrance,
        MapExit
    }
    public Dictionary<Type, string> RoomTypeSymbols = new()
    {
        { Type.Empty, "▄" },
        { Type.Activity, "☼" },
        { Type.MapEntrance, "◄"},
        { Type.MapExit, "►"},
    };

    public Room(Coordinates coordinates, Type roomType = Type.Empty, Direction? doors = null, Activity? activity = null)
    {
        Coordinates = coordinates;
        RoomType = roomType;
        Doors = doors ?? 0;
        if (roomType != Type.Activity && activity is not null || roomType == Type.Activity && activity is null)
            Errors.Report(Errors.Code.RoomTypeDoesNotMatchActivity);
        Activity = activity;
    }
    public void SetEntranceOrigin(World? origin = null)
    {
        EntranceOrigin = origin;
    }

    public void SetExitDestination(World destination)
    {
        ExitDestination = destination;
    }

    public void SetRoomType(Type type)
    {
        RoomType = type;
    }

    public void ShowRoom()
    {
        if (Doors.HasFlag(Direction.North | Direction.South)) Console.Write("║");
        else if (Doors.HasFlag(Direction.West | Direction.East)) Console.Write("═");
        else if (Doors.HasFlag(Direction.South | Direction.East)) Console.Write("╔");
        else if (Doors.HasFlag(Direction.South | Direction.East | Direction.West)) Console.Write("╦");
        else if (Doors.HasFlag(Direction.South | Direction.West)) Console.Write("╗");
        else if (Doors.HasFlag(Direction.South | Direction.East | Direction.North)) Console.Write("╠");
        else if (Doors.HasFlag(Direction.South | Direction.East | Direction.North | Direction.West)) Console.Write("╬");
        else if (Doors.HasFlag(Direction.South | Direction.North | Direction.West)) Console.Write("╣");
        else if (Doors.HasFlag(Direction.North | Direction.East)) Console.Write("╚");
        else if (Doors.HasFlag(Direction.East | Direction.North | Direction.West)) Console.Write("╩");
        else if (Doors.HasFlag(Direction.North | Direction.West)) Console.Write("╝");
        else Console.WriteLine("□");
    }
}