using System.Security.Cryptography;

static class ItemGenerator
{
    private static readonly List<Func<Equpipable>> equipableFactories = new()
    {
        () => new ChestPiece("Knight's Armor"),
        () => new Helmet("Knight's Helmet"),
    };

    static public Equpipable GenerateEqupipable(int level)
    {
        return equipableFactories[RandomNumberGenerator.GetInt32(0, equipableFactories.Count)]();
    }
}