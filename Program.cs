using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Project.Game game = new Project.Game();
      game.Setup();

      while (game.Playing)
      {
        game.Look();
        string userChoice = game.UserInput().ToLower();
        string[] userAction = userChoice.Split(' ');
        if (userAction[0] == "l" || userAction[0] == "look")
        {
          Console.Clear();
          game.Look();
        }
        else if (userAction[0] == "h" || userAction[0] == "help")
        {
          Console.WriteLine("Look around room: l or look");
          Console.WriteLine("Take item: t or take");
          Console.WriteLine("View inventory: i or inventory");
          Console.WriteLine("Use item: u or use");
          Console.WriteLine("Quit: q or quit");
          Console.WriteLine("Select choice: enter number or name of choice");
          Console.WriteLine("To answer puzzles, simple type and enter your answer.");
        }
        else if (userAction[0] == "t" || userAction[0] == "take")
        {
          string choice = "";
          for (int i = 1; i < userAction.Length; i++)
          {
            choice += userAction[i] + " ";
          }
          game.TakeItem(choice.Trim());
        }
        else if (userAction[0] == "i" || userAction[0] == "inventory")
        {
          Console.Clear();
          Console.WriteLine("Inventory: ");
          game.CurrentPlayer.Inventory.ForEach(item =>
          {
            Console.WriteLine(item.Name);
          });
        }
        else if (userAction[0] == "u" || userAction[0] == "use")
        {
          string choice = "";
          for (int i = 1; i < userAction.Length; i++)
          {
            choice += userAction[i] + " ";
          }
          game.UseItem(choice.Trim());
        }
        else if (userAction[0] == "q" || userAction[0] == "quit")
        {
          Console.Clear();
          Console.WriteLine("Are you sure you wanna give up??? Y/n");
          string answer = Console.ReadLine().ToLower();
          if (answer == "y" || answer == "yes")
          {
            game.Playing = false;
          }
        }
        else
        {
          Console.Clear();
          game.CheckChoice(userChoice.Trim());
        }
        game.CheckRoom();
        if (game.Playing == false)
        {
          Console.WriteLine("Wanna play again??? Y/n");
          string input = Console.ReadLine();
          if (input == "y" || input == "yes")
          {
            game.Setup();
            game.Playing = true;
          }
        }
      }
    }
  }
}
