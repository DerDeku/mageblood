using System.Security.Cryptography;
using Mageblood;

class Coordinates
{
    public int X { get; init; }
    public int Y { get; init; }
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Coordinates(Tuple<int,int> coordinates)
    {
        X = coordinates.Item1;
        Y = coordinates.Item2;
    }
    public Coordinates(Tuple<int,int> coordinates, bool fromIndex) : this(coordinates)
    {
        if (fromIndex)
            X++;
            Y++;
    }

    public Coordinates AsIndex()
    {
        return new Coordinates(X-1, Y-1);
    }    

    public Coordinates? GetCoordinatesInDirection(Direction direction)
    {
        if (direction == Direction.North) return new Coordinates(X, Y+1);
        else if (direction == Direction.East) return new Coordinates(X+1, Y);
        
        else if (direction == Direction.South)
        {
            if (Y == 0)
                return null;
            return new Coordinates(X, Y-1);
        }

        else // West
        {
            if (X == 0)
                return null;
            return new Coordinates(X-1, Y);
        }
    }
}