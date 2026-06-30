
class Map
{
    string Name;
    private readonly Room[,] room;
    public Map(string name, int sizeX, int sizeY)
    {
        Name = name;
        room = new Room[sizeY,sizeX];
    }

    public void AddRoom(Room room, Coordinates coordinates)
    {
        if (this.room[coordinates.Y, coordinates.X] != null)
        {
            Error.Print(Error.Code.MapAlreadyHasRoomAtCoordinates);
        }

        this.room[coordinates.Y, coordinates.X] = room;
    }

    public Room? GetRoom(Coordinates coordinates)
    {
        return room[coordinates.Y, coordinates.X];
    }
}