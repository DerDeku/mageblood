using Mageblood;

class Map
{
    string Name;
    public readonly Room[,] Rooms;
    public Coordinates? CoordinatesEntrance {get; set; } = null;
    public Coordinates? CoordinatesExit {get; set; } = null;
    public Map(string name, int sizeX, int sizeY)
    {
        Name = name;
        Rooms = new Room[sizeY,sizeX];
    }

    public enum Type
    {
        Dungeon1
    }

    public void AddRoom(Room room, Coordinates coordinates)
    {
        if (Rooms[coordinates.Y, coordinates.X] != null)
        {
            Errors.Report(Errors.Code.MapAlreadyHasRoomAtCoordinates);
        }

        Rooms[coordinates.Y, coordinates.X] = room;
    }

    public Room? GetRoom(Coordinates coordinates)
    {
        (int sizeX, int sizeY) = GetSize();
        if (coordinates.X > sizeX || coordinates.Y > sizeY || coordinates.X <= 0 || coordinates.Y <= 0) {Errors.Report(Errors.Code.CoordinatesOutOfBounds); return null;}
        return Rooms[coordinates.Y-1, coordinates.X-1];
    }

    public Room? GetRoomInDirection(Coordinates coordinatesRoom, Direction direction)
    {
        Coordinates? coordinatesNewRoom = coordinatesRoom.GetCoordinatesInDirection(direction);
        if (coordinatesNewRoom is null) return null;

        return GetRoom(coordinatesNewRoom);
    }

    /// <returns>SizeX, SizeY</returns>
    public Tuple<int,int> GetSize()
    {
        return new Tuple<int,int>(Rooms.GetLength(0), Rooms.GetLength(1));
    }

    public void PrintMap()
    {
        (int sizeX, int sizeY) = GetSize();
        for (int y = 0; y < sizeY; y++)
        {
            Console.WriteLine();
            for (int x = 0; x < sizeX; x++)
            {
                Rooms[y,x].ShowRoom();
            }
        }
    }

}