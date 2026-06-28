public abstract class Equpipable : Item
{
    protected int maxStats;
    public List<Stat> stats = new();
    public List<Stat> baseStats = new();

    public void AddStat(Stat newStat)
    {
        if (stats.Count >= maxStats) { Error.Print(Error.Code.ItemHasTooManyStatsAlready); return; }
        stats.Add(newStat);
    }

    public void ShowStats()
    {
        Console.WriteLine($"== {this.name} ==");
        foreach (Stat stat in baseStats)
        {
            Console.WriteLine($"{stat.name}: {stat.value}");
        }
        foreach (Stat stat in stats)
        {
            Console.WriteLine($"{stat.name}: {stat.value}");
        }
    }
}
