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
      bool quit = false;

      while (game.Playing)
      {
        game.Look();
        string userChoice = game.UserInput().ToLower();
        string[] userAction = userChoice.Split(' ');
        switch (userAction[0])
        {
          case "l":
          case "look":
            Console.Clear();
            game.Look();
            break;
          case "h":
          case "help":
            Console.Clear();
            Console.WriteLine("Look around room: l or look");
            Console.WriteLine("Take item: t or take");
            Console.WriteLine("View inventory: i or inventory");
            Console.WriteLine("Use item: u or use");
            Console.WriteLine("Quit: q or quit");
            Console.WriteLine("To get a cheat: c or cheat");
            Console.WriteLine("Select choice: enter number or name of choice");
            Console.WriteLine("To answer puzzles, simple type and enter your answer. \n");
            break;
          case "t":
          case "take":
            Console.Clear();
            string choice = "";
            for (int i = 1; i < userAction.Length; i++)
            {
              choice += userAction[i] + " ";
            }
            game.TakeItem(choice.Trim());
            break;
          case "i":
          case "inventory":
            Console.Clear();
            Console.WriteLine("Inventory: ");
            game.CurrentPlayer.Inventory.ForEach(item =>
            {
              Console.WriteLine(item.Name + ":" + " " + item.Description);
            });
            Console.WriteLine();
            break;
          case "u":
          case "use":
            Console.Clear();
            string useChoice = "";
            for (int i = 1; i < userAction.Length; i++)
            {
              useChoice += userAction[i] + " ";
            }
            game.UseItem(useChoice.Trim());
            break;
          case "q":
          case "quit":
            Console.Clear();
            Console.WriteLine("Are you sure you wanna give up??? Y/n");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes")
            {
              quit = true;
              game.Playing = false;
            }
            break;
          case "c":
          case "cheat":
            Console.Clear();
            if (game.CurrentRoom.Cheat.Length > 0)
            {
              Console.WriteLine("cheat: " + game.CurrentRoom.Cheat);
            }
            else
            {
              Console.WriteLine("Well... to late now...");
            }
            break;
          case "go":
          case "g":
            Console.Clear();
            string goChoice = "";
            for (int i = 1; i < userAction.Length; i++)
            {
              goChoice += userAction[i] + " ";
            }
            game.CheckChoice(goChoice.Trim());
            break;
          default:
            Console.Clear();
            game.CheckChoice(userChoice.Trim());
            break;
        }
        game.CheckRoom();
        if (game.Playing == false && quit == false)
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
      Console.Clear();
      Console.ResetColor();
    }
  }
}

