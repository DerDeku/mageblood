using System.Security.Cryptography;

static class StatGenerator
{
    private static readonly List<Func<Stat>> statFactories = new()
    {
        () => new Stat("+# to maximum hitpoints", 40),
        () => new Stat("+# to maximum strength", 5),
    };

    static public Stat Generate(int level)
    {
        return statFactories[RandomNumberGenerator.GetInt32(0, statFactories.Count)]();
    }
}