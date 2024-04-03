using System;
using System.Collections.Generic;
using System.Diagnostics;

class Player
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
  public List<Character> Characters { get; set; }
  public List<Location> Locations { get; set; }
  public List<Event> Events { get; set; }

  public Wolrd()
  {
    Characters = new List<Character>();
    Locations = new List<Locations>();
    Events = new List<Events>();
  }

  public void AddCharacter(string name, string role, int age)
  {
    Characters.Add(new Character { Name = name, Role = role, Age = age });
  }

  public void AddLocation(string name, string description)
  {
    Locations.Add(new Location { Name = name, Description = description });
  }

  public void AddEvent(string name, string description, DateTime date)
  {
    Events.Add(new Event { Name = name, Description = description, Date = date });
  }
}

class Program
{
  static void Main(string[] args)
  {
    World myWorld = new World();

    DateTime currentDateTime = DateTime.Now;

    GameClock gameClock = new GameClock();
    gameClock.Start();

    Console.WriteLine("Press any key. Press 'esc' to quit.");

    myWorld.AddCharacter("Player", "Villager", 18);

    myWorld.AddLocation("Village", "Hometown, the place where u were raised");

    myWorld.AddEvent("New Year", "Celebrate the earth rotating around the Sun 1 full time", new DateTime(2024, 1, 1));

    Console.WriteLine("Characters:");
    foreach (var character in myWorld.Characters)
    {
      Console.WriteLine($"Name: {character.Name}, Role: {character.Role}, Age: {character.Age}");
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

      if (keyInfo.KeyChar == 'esc')
      {
          Console.WriteLine("Exiting...");
          gameClock.Stop();
          TimeSpan elapsedTime = gameClock.ElapsedTime();
          Console.Write("Time played is " + elapsedTime);
          break;
      }
    }
  }
  }
