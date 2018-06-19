using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Player : IPlayer
  {
    public int Score { get; set; }
    public List<Item> Inventory { get; set; }
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
        Inventory = new List<Item>();
    }

    public void DrawInventory() 
    {
        Console.WriteLine("You have: \n");
        Inventory.ForEach(item => {
            Console.WriteLine(item.Name+ "---" +item.Description);
        });
    }
    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine(item.Name + "Added to inventory!");
    }

    public void RemoveItem(Item item) 
    {
        Inventory.Remove(item);
        Console.WriteLine(item.Name + "removed from inventory!");
    }
  }
}