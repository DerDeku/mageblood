class World
{
    string Name;
    private readonly List<Map> maps;
    public World(string name)
    {
        Name = name;
        maps = new List<Map>();
    }

    public void AddMap(Map map)
    {
        maps.Add(map);
    }

    public Map? GetMap(int level)
    {
        //Levels start at Level 1!
        return maps[level-1];
    }
}