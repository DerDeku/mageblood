public class Game
{
    public Player Player { get; init; }
    private World World;
    public Game()
    {
        Player = new Player();
        SetupGame();
        GenerateItem();
        Gameloop();
    }
    public void SetupGame()
    {
        World = new("Bloouria");
        World.AddMap(MapGenerator.GenerateMap("Prison", 5,5, Map.Type.Dungeon1)); // Level 1 - Prison 5x5
    }

    public void Gameloop()
    {
        while(true)
        {
            Console.WriteLine("1 - Generate new Item");
            Console.WriteLine("2 - Show Player stats");
            Console.WriteLine("3 - Drink from well (restore all ressources)");
            Console.WriteLine("x - Beenden");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    GenerateItem();
                break;

                case "2":
                    Player.ShowStats();
                break;

                case "3":
                    Player.RestoreRessources();
                break;

                case "x":
                return;
                

                default:
                    continue;
            }
        }
    }

    public void GenerateItem()
    {
        Console.WriteLine("Generate Item");
        Equpipable equipment = ItemGenerator.GenerateEqupipable(1);
        equipment.AddStat(StatGenerator.Generate(1));
        equipment.AddStat(StatGenerator.Generate(1));
        equipment.AddStat(StatGenerator.Generate(1));
        equipment.ShowStats();
        Console.WriteLine("Equip Item y/n?");
        if (Console.ReadLine() == "y")
            Player.EquipItem(equipment);
        else
            Player.inventory.AddItem(equipment);
        
    }

}