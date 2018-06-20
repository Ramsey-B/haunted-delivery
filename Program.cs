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
        else if(userAction[0] == "h" || userAction[0] == "help") {

        }
        else if(userAction[0] == "t" || userAction[0] == "take" && userAction[1] != null) {
          string choice = "";
          for (int i = 1; i < userAction.Length; i++)
          {
            choice += userAction[i] + " ";
          }
          game.TakeItem(choice);
        }
        else if (userAction[0] == "i" || userAction[0] == "inventory") {

        }
        else
        {
          
          game.CheckChoice(userChoice.Trim());
        }
        Console.Clear();
        game.CheckRoom();
      }
    }
  }
}
