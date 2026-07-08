

using Mageblood;

static class MapGenerator
{
    static Map Map;
    static Map[] MainPath;
    public static Map GenerateMap(string name, int mapSizeX, int mapSizeY, Map.Type mapType)
    {
        InstanciateMap(name, mapSizeX, mapSizeY);
        FillMapWithEmptyRooms();
        Map.PrintMap();
        GeneratePaths(mapType);

        return Map;
    }

    private static void GeneratePaths(Map.Type mapType)
    {
        switch (mapType)
        {
            case Map.Type.Dungeon1:
                GenerateDungeon1Map();
            break;

            default:
                GenerateDungeon1Map();
            break;
        }
    }

    private static void GenerateDungeon1Map()
    {
        AddEntranceAndExit(new Coordinates(1,1), new Coordinates(Map.GetSize()));
        (int sizeX, int sizeY) = Map.GetSize();
        int mainPathLength = sizeX + sizeY;
        MainPath = new Map[mainPathLength];
        GenerateMainPath(mainPathLength);
    }

    private static void GenerateMainPath(int mainPathLength)
    {
        Room? entrance = Map.GetRoom(Map.CoordinatesEntrance);
        if (entrance is null) Errors.Report(Errors.Code.MapGenerationFailed);
        Room newRoom = GetRandomRoom(entrance!);        
    }
    
    private static Room GetRandomRoom(Room room)
    {
        while (true)
        {
            Direction randomDirection = GetRandomDirection();
            Room? newRoom = Map.GetRoomInDirection(room.Coordinates, randomDirection);
            if (newRoom is not null) return newRoom;
        }
    }

    private static void InstanciateMap(string name, int sizeX, int sizeY)
    {
        Map = new Map(name, sizeX, sizeY);
    }

    private static void AddEntranceAndExit(Coordinates CoordinatesEntrance, Coordinates CoordinatesExit)
    {
        Map.GetRoom(CoordinatesEntrance)?.SetRoomType(Room.Type.MapEntrance);
        Map.GetRoom(CoordinatesExit)?.SetRoomType(Room.Type.MapExit);
        Map.CoordinatesEntrance = CoordinatesEntrance;
        Map.CoordinatesExit = CoordinatesExit;
    }

    private static void FillMapWithEmptyRooms()
    {
        for (int y = 0; y < Map.Rooms.GetLength(0); y++)
        {
            for (int x = 0; x < Map.Rooms.GetLength(1); x++)
            {
                Map.Rooms[y, x] = new Room(new Coordinates(new(x,y), fromIndex: true));
            }
        }
    }

    private static Direction GetRandomDirection()
    {
        return Enum.GetValues<Direction>()[new Random().Next(Enum.GetValues<Direction>().Length)];
    }

}