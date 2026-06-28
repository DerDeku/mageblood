public class Game
{
    public Player player { get; init; }

    public Game()
    {
        player = new Player();
        SetupGame();
        GenerateItem();
        Gameloop();
    }
    public void SetupGame()
    {
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
                    player.ShowStats();
                break;

                case "3":
                    player.RestoreRessources();
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
            player.EquipItem(equipment);
        else
            player.inventory.AddItem(equipment);
        
    }

}