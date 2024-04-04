  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  
  class NPC
  {
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
  }
  
  class Location
  {
    public string Name { get; set; }
    public string Description {get; set; }
  }
  
  class Event
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
  }
  
  class GameClock
  {
      private Stopwatch stopwatch;
  
      public GameClock()
      {
          stopwatch = new Stopwatch();
      }
  
      public void Start()
      {
          stopwatch.Start();
      }
  
      public void Stop()
      {
          stopwatch.Stop();
      }
  
      public void Reset()
      {
          stopwatch.Reset();
      }
  
      public TimeSpan ElapsedTime()
      {
          return stopwatch.Elapsed;
      }
  }
  
  class World
  {
    public List<NPC> NPC { get; set; }
    public List<Location> Locations { get; set; }
    public List<Event> Events { get; set; }
  
    public Wolrd()
    {
    	NPC = new List<NPC>();
    	Locations = new List<Locations>();
    	Events = new List<Events>();
    }
  
    public void AddNPC(string name, string role, int age)
    {
    	NPC.Add(new NPC { Name = name, Role = role, Age = age });
    }
  
    public void AddLocation(string name, string description)
    {
    	Locations.Add(new Location { Name = name, Description = description });
    }
  
    public void AddEvent(string name, DateTime date)
	{
		Events.Add(new Event { Name = name, Description = description, Date = date });
	
  }

record Player(int X, int y, int Coins)
{
    public Player(int x, int y) : this(x, default, 0)
    {
        Y = y;
    }

    public void Move(int deltaX, int deltaY)
    {
        X += deltaX;
        Y += deltaY;
    }

    public void Mine(Resource resource)
    {
        //change coins later when inventory added
        Coins += recource.Value;
        Console.WriteLine($"You mined {resource.Value} coins. Total coins {Coins}");
    }
}

class Resource
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Value { get; set; }

		public Resource(int x, int y, int value)
		{
			X = x;
			Y = y;
			Value = value;
		}
	}

  public class PlayerInventory
  {
    private Dictionary<string, int> items;

    public PlayerInventory()
    {
      items = new Dictionary<string, int>();
    }

    public void AddItem(string itemName, int quantity)
    {
      if(items.ContainsKey(itemName))
      {
        items[itemName] += quanity;
      }
      else
      {
        items[itemName] = quantity;
      }
    }

    public void RemoveItem(string itemName, int quanity)
    {
      if(items.ContainsKey(itemName))
      {
        items[itemName] -= quanity;
        if(items[itemName] <= 0)
        {
          items.Remove(itemName);
        }
      }
      else
      {
        Console.WriteLine("Item not found in Inventory.");
      }
    }

    public void DisplayInventory()
    {
      Console.WriteLine("Inventory: ");
      foreach (var item in items)
      {
        Console.WriteLine($"{item.Key}: {item.Value}");
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      World myWorld = new World();
			const int MapWidth = 100;
			const int MapHeight = 100;

			//Player creation
			Player player = new Player(0,0);

      //Player inventory
      PlayerInventory playerInventory = new PlayerInventory();
      playerInventory.AddItem("wooden sword", 1);
			
			//resource code
			Random random = new Random();
			Resource[] resources = new Resource[MapWidth * MapHeight];
			for (int i =0; i<resources.Length; i++)
			{
				int x = random.Next(MapWidth);
				int y = random.Next(MapHeight);
				int value = random.Next(1, 100000);
				resources[i] = new Resource(x, y, value);
			}
			
			
      DateTime currentDateTime = DateTime.Now;
  
      GameClock gameClock = new GameClock();
      gameClock.Start();
  
      Console.WriteLine("Press any key. Press 'esc' to quit.");
  
      myWorld.AddNPC("Player", "Villager", 18);
  
      myWorld.AddLocation("Village", "Hometown, the place where u were raised");
  
      myWorld.AddEvent("New Year", "Celebrate the earth rotating around the Sun 1 full time", new DateTime(2024, 1, 1));
  
      Console.WriteLine("NPC:");
      foreach (var NPC in myWorld.NPC)
      {
        Console.WriteLine($"Name: {NPC.Name}, Role: {NPC.Role}, Age: {NPC.Age}");
      }
  
      Console.WriteLine("\nLocations:");
      foreach (var location in myWorld.Locations)
      {
        Console.WriteLine($"Name: {location.Name}, Description: {location.Description}");
      }
  
      Console.WriteLine("\nEvents:");
      foreach (var events in myWorld.Events)
      {
          Console.WriteLine($"Name: {events.Name}, Description: {events.Description}, Date: {events.Date.ToShortDateString()}");
      }
  
      while (true)
      {
  
        ConsoleKeyInfo keyInfo = Console.ReadKey();
				Console.WriteLine($"\nYou pressed: {keyInfo.KeyChar}");
				Console.WriteLine($"Player position: ({player.X}, {player.Y})");

				foreach (Resource resource in resources)
				{
					if(resource.X == player.X && resource.Y == player.Y)
					{
						player.Mine(resource);
						resource.X = random.Next(MapWidth);
						resource.Y = random.Next(MapHeight);
					}
				}

				//movement and controls of the player
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				Console.WriteLine();
				switch (keyInfo.Key)
				{
					case ConsoleKey.W:
						player.Move(0, 1);
						break;
					case ConsoleKey.S:
						player.Move(0,-1);
						break;
					case ConsoleKey.A:
						player.Move(-1,0);
						break;
					case ConsoleKey.D:
						player.Move(1,0);
						break;
					default:
						Console.WriteLine("Invalid input");
						break
				  
        if (keyInfo.KeyChar == 'esc')
        {
            Console.WriteLine("Exiting...");
            gameClock.Stop();
            TimeSpan elapsedTime = gameClock.ElapsedTime();
            Console.Write("Time played is " + elapsedTime);
            break;
        }

        if (keyInfo.Key == ConsoleKey.I)
        {
          Console.WriteLine("Displaying Inventory");
          playerInventory.DisplayInventory();

          //spare code for when hovering over items is available
          //playerInventory.RemoveItem(item)
        }
      }
    }
  }
}
