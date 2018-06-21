using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Cheat { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, Room> Exits = new Dictionary<string, Room>();

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Cheat = "";
      Items = new List<Item>();
    }
    public Room(string name, string description, string cheat)
    {
      Name = name;
      Description = description;
      Cheat = cheat;
      Items = new List<Item>();
    }

    public void AddExit(string direction, Room room)
    {
      Exits.Add(direction, room);
    }

    public void UseItem(Item item)
    {

    }
  }
}