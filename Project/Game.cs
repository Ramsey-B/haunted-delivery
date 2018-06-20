using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public List<Room> Rooms = new List<Room>();
    public Boolean Playing { get; set; }

    public void Reset()
    {

    }

    public void Setup()
    {
      CreateRooms();
      CurrentRoom = Rooms[0];
      Console.WriteLine("Welcome to Domino's!");
      Console.WriteLine("What is your name? \n");
      string PlayerName = Console.ReadLine();
      Console.WriteLine("Hello, " + PlayerName + " You got deliveries to take!");
      CurrentPlayer = new Player(PlayerName);
      Playing = true;

    }

    public void Look()
    {
      Console.WriteLine($"{CurrentRoom.Name}: {CurrentRoom.Description}");
      Console.WriteLine("Item(s): ");
      if (CurrentRoom.Items.Count == 0)
      {
        Console.WriteLine("You're no MacGyver, there's nothing here you can use...");
      }
      else
      {
        for (int i = 0; i < CurrentRoom.Items.Count; i++)
        {
          Console.WriteLine(CurrentRoom.Items[i].Name);
        }
      }
    }

    public string UserInput()
    {
      Console.WriteLine("What do you do?");
      Console.WriteLine("choices: ");
      foreach (string key in CurrentRoom.Exits.Keys)
      {
        Console.WriteLine(key);
      }
      string input = Console.ReadLine();
      return input;
    }

    public void CheckChoice(string input)
    {
      if (CurrentRoom.Exits.ContainsKey(input))
      {
        CurrentRoom = CurrentRoom.Exits[input];
      }
      else if (CurrentRoom.Name == "puzzle room")
      {
        if (input.Contains("hole"))
        {
          Room room = Rooms.Find(r =>
          {
            return r.Name == "puzzle right";
          });
          Console.WriteLine(room.Description);
          Console.WriteLine("You lose!");

          Playing = false;
        }
        else
        {
          CurrentRoom = Rooms[11];
        }
      }
      else
      {
        Console.Clear();
        Console.WriteLine("I know this is hard, so lets try it again.");
      }
    }

    public void CheckRoom()
    {
      if (CurrentRoom.Name == "look at shia")
      {
        Item shiaLabeouf = new Item("shia labeouf", "He's following you about thirty feet back. It's actual cannibal Shia Labeouf, and he's brandishing a knife.");
        CurrentPlayer.Inventory.Add(shiaLabeouf);
        Rooms[4].Exits.Remove("second door");
      }
    }

    public void TakeItem(string choice)
    {
      Item itemChoice = CurrentRoom.Items.Find(item =>
      {
        return item.Name == choice;
      });
      if (itemChoice == null)
      {
        Console.WriteLine("You attempt to grab the " + choice + " and now realize you're the reason companies drug test.");
      }
      else
      {
        if (itemChoice.Name == "flashlight" || itemChoice.Name == "glasses" && CurrentRoom.Name == "choice room")
        {
          CurrentPlayer.Inventory.Add(itemChoice);
          string otherItem = itemChoice.Name == "flashlight" ? "glasses" : "flashlight";
          Console.WriteLine("You pick up the " + itemChoice.Name + ", but the board shifts. The " + otherItem + " tumble off into the dark!");
          CurrentRoom.Items.RemoveAll(item =>
          {
            return item.Name == "flashlight" || item.Name == "glasses";
          });
        }
        else
        {
          CurrentPlayer.Inventory.Add(itemChoice);
          CurrentRoom.Items.Remove(itemChoice);
          Console.WriteLine("You picked up a " + itemChoice.Name);
        }
      }
    }
    public void UseItem(string itemName)
    {
      Item choice = CurrentPlayer.Inventory.Find(item => item.Name == itemName);
      if (choice != null)
      {
        if (choice.Name == "shia labeouf" && CurrentRoom.Name == "tunnel door")
        {
          Console.Clear();
          Console.WriteLine("You begin to sob uncontrollably! Seeing this, Shia Labeouf springs to action! He sprints to and begins screaming at you 'Just do it!!!' His motivation gives you the confidence you need! You begin yelling back at the lady! Things are going great... Till suddenly Shia takes an axe to the woman... He definitely just murdered the woman... The two of you leave and actual murders Shia Labeouf and his trust accomplice" + CurrentPlayer.Name + "ride off into the sunset! You Win!!!");
          CurrentPlayer.Inventory.Remove(choice);
          Playing = false;
        }
        else if (choice.Name == "flashlight" && CurrentRoom.Name == "dark tunnel")
        {
          Console.Clear();
          Console.WriteLine("The tunnel brightens! Though you kind of wish it didn't... There's dismembered body's and blood everywhere! But you notice a crack in the wall that looks like a way out!");
          CurrentRoom.AddExit("escape tunnel", Rooms[32]);
          CurrentPlayer.Inventory.Remove(choice);
        }
        else if (choice.Name == "glasses" && CurrentRoom.Name == "clock room")
        {
          Console.Clear();
          Console.WriteLine("You put on the glasses. At first things are blurry, but you feel your perception rise. One clock stands out more than the rest... It's a digital clock where the numbers decend slowly down as time continues. But you notice the time is not changing, It's stuck on 1:58...");
          CurrentPlayer.Inventory.Remove(choice);
        }
        else
        {
          Console.Clear();
          if (choice.Name == "shia labeouf")
          {
            Console.WriteLine("You see him out the corner of you eye following about 30 feet back. He's down on all fours, but it's not his time yet");
          }
          else if (choice.Name == "flashlight")
          {
            Console.WriteLine("It turns on, but you turn it off quickly feeling as though it maybe be more useful later...");
          }
          else if (choice.Name == "glasses")
          {
            Console.WriteLine("You put them on and struggle to see. Obviously... Why would they be your prescription??? You do feel as though your perception rises... Maybe that could be useful.");
          }
          else if (choice.Name == "envelope")
          {
            Console.WriteLine("You open the envelope to find 86 cents in assorted coins. Who tips in change?");
          }
        }
      }
      else
      {
        Console.WriteLine("You take the " + itemName + " and place it in your mouth... weird...");
      }
    }

    public void CreateRooms()
    {
      Room start = new Room("start", "You are a pizza delivery driver. You have an order to an old country house. This is a strange house. It's miles outside of town in the middle of the forrest. The house is down a long gravel road in a small forrest clearing. It's dark. Your headlights and the moon are the only sources of light. It's unusually quiet for a forrest. You arrive at an acient house that matches the address. You get out grab the order from your car.");
      Room knock = new Room("knock", "You approach the door and knock. There's no answer. But you hear some russling in the bushes...");
      Room frontDoor = new Room("front door", "Theres no answer. Nothing... The russling in the forrest seems to get louder... You knock again, but nothing. It now sounds as if the russling sounds are coming towards you. They're getting faster and faster. The door then creeks open...");
      Room enterance = new Room("enterance", "You enter the house, and the door slams shut. It's old and dusty, as if abandoned long ago. Hopefully, its not a prank, you can't afford to waste the gas! Before you is a large staircase that seems to spiral off into a dark abyss. To your left is a long dark hallway that if you listen carefully you hushed and anguished 'shhhh'. To your right is an old and cracked door.");
      Room darkHall = new Room("dark hallway", "You carefully navigate down the hallway. As you get further you see two doors. The first door is old, with peeling paint. The second door looks the same as the first but its clear now, the sound from earlier and a faint weeping noise are emminating from the room.");
      Room shia = new Room("mysterious room", "The door creeks open. Before you stands an axe weilding figure in a bloody tuxedo. He appears to be eating the leg of another delivery driver!");
      Room shia2 = new Room("enter mysterious room", "As you enter, you hear a loud 'Shia LaBeouf', and before you stands actual cannibal Shia LaBeouf! He drops the leg of the poor Pizza Hut driver, he gets down on all fours and prepares to sprint. He's staring right at you.");
      Room shia3 = new Room("look at shia", "You stare back... (you must be mad)... Shia's eyes begin to water. He stares more and more intently... Finally he blinks. Out of respect Shia LaBeouf joins your party! He's now a useable Item!");
      Room shiaDeath = new Room("leave mystery room", "You begin to leave. Shia LaBeouf begins sprinting at you. Hes gaining on you! You head for your car but you're all turned around! Theres blood on his face! Oh my god, there's blood everywhere! He's brandishing a knife, it's Shia Labeouf! You lack Jiu Jitsu skills to survive. You're never heard from again.");
      Room puzzle = new Room("puzzle room", "You walk in the room, theres an old, decrepit man sitting in the corner. He rises slowly. He says in a feeble voice 'If you can answer this riddle, I will help you find the one you seek... The more you cut me, the more I grow. What am I?'");
      Room puzzleRight = new Room("puzzle right", "He smirks and proceeds to open the next door. As you walk through the floor boards begin shreek. They break, sending you falling into a dark cavern of certain death! The last thing you hear is the old man yell 'I warned you!'");
      Room puzzleWrong = new Room("puzzle wrong", "The old man appears angry. He begins yelling 'A hole! I am a hole!' He then throws the next door open and it breaks from the hinges. It lands on the floor breaking the floor boards and opening a massive chasm that swallows the old man whole. The door however appears to make a bridge accross.");
      Room chasmRoom = new Room("chasm room", "You gingerly but safely cross the door. The room has two doors. The door to your left seems to lead towards a room that has also been partially swallowed by the hole. The door to your right is seems fairly normal for this house.");
      Room choiceRoom = new Room("choice room", "You walk into the room to see a another dark cavern. There appears to be a board balance on one end by what appears to be a gun, and on the other end is a flashlight");
      Room chasmRoom2 = new Room("chasm room again", "You pass back through the chasm room and notice the door is gone. The only choice left is to go through the other door. It appears to be long dark hallway. At the end is door. You open it, only to notice. It's a hidden door leading back to the main enterance.");
      Room returnHall = new Room("secret hall", "It appears to be long dark hallway. At the end is door. You open it, only to notice. It's a hidden door leading back to the main enterance. What a waste.");
      Room emptyRoom = new Room("empty room", "The room appears to be entirely empty... You look around for a minute, till you notice a window. Through the window, you see a pair of eyes. They're wide open, open more than you thought possible... They're looking right at you. You can tell they're breathing but the figure remains still.");
      Room upStairs = new Room("upstairs", "At the top of the old creeky stairs you find a long dark hallway. To your left is a door that you can hear the giggles madman. The door to the right you hear an ominous scratching sound.");
      Room scratchingRoom = new Room("scratching room", "You enter the room. It's dark and dusty but you can make out what appears to be an arm! You now realize the scratching noise is the the arm clawing at the floor boards!");
      Room approachArm = new Room("approach arm", "As you approach the arm you know see its still attached to th torso under the floor boards! you cant make out what the person looks like, but you can now see that they're trying to give you can envelope!");
      Room takeEnvelope = new Room("take envelope", "You turn to leave but the hand grabs you! You stop and look. It then begins pointing frantically at another door! The door is covered in streamers and balloons. How did you miss it?");
      Room partyRoom = new Room("party room", "You open the door and are hit with a blinding light. Heaven? No. It appears every light in this forsaken home has been placed in this room. Somehow, its the worst room you've ever seen. It's a young kids birthday party! They spotted you! You run but the had trips you! Suddenly you're surrounded by a Pizza drivers worst nightmare... hungry kids. Like a pack of wolves, the devoure you!");
      Room crazyMan = new Room("laughing room", "Immediately as the door opens, water begins pouring out and flooding the hallway. It smells awful. At first there doesn't seem to be a source to the laughter. But suddenly, a figure rises from a pool of water in the center of the room. It's a birthday clown. He appears to have been attacked by some pack of wolves! He quickly runs and jumps out a window, sreaming wildly.");
      Room endHall = new Room("end of hallway", "At the end of a hallway is a door with a mirror. Foolishly you look into the mirror. In it, you notice a tall, boney woman standing at the top of the stairs. Shes looking straight at you. Her eyes open wider than you thought possible. Shes brandishing an old rusty knife. To your left and right are two doors. To the right a seemingly normal door. To the left, is a slightly cracked open door, inside you chains, knives, and hooks hanging on the wall.");
      Room backHall = new Room("go back to stairs", "Like a true hero, you turn to face the woman, but shes gone... cause obviously... The door now behind you swings open and the woman you saw before jams the knife into you. As the world goes dim, you watch helplessly as she takes the pizza.");
      Room leftDoor = new Room("clock room", "You open the door to find a room full of clocks... The ticking is maddening... The clocks are hard to read. Something seems off about this room...");
      Room rightDoor = new Room("murder room", "As you might've guessed, this reeks of death. Outside door hear footsteps. You could grab a weapon, but those are against Domino's policy! Your only choice is to hide. You can see a desk covered in blood that you could hide under.");
      Room underDesk = new Room("under desk", "Under the desk you can only see a couple inches off the floor. A figure walks in, but you can only see their bare, grey feet... They wait some time before leaving.");
      Room playDead = new Room("play dead", "A drop to the floor like a dead fish. The woman enters the room and looks at you for sometime. She then picks you up by the ankles and drags you off");
      Room continuePlayDead = new Room("keeping play dead", "She drags you into the mirrored door room. You can now see that it was not a mirror, but rather a window. She then chucks you onto a pile of bodies and leaves. You can follow her, but you also spot a dark smelly hole in the wall.");
      Room darkTunnel = new Room("dark tunnel", "You shuffle over the bodies into the dark tunnel. It's pitch black.");
      Room escapeTunnel = new Room("escape tunnel", "You push on the crack. It bursts open sending you plummeting to the ground outside. You're free! Or so you thought. Now you're all alone in the woods. Your phone is dead. Out the corner of your eyes you spot him. Actual cannibal Shia LaBeouf is now following you at 30 feet back. He gets on all fours and begins sprinting. He's gaining on you!");
      Room tunnelDoor = new Room("tunnel door", "You open the door. You walk in and find a empty table in an otherwise empty room. The door shuts behind you, but you didn't shut it! You turn to discover a soccer mom! She begins yelling! 'Its been over 30 minutes! My food should be free!'. You look at the ticket but notice its only been 25 minutes since she ordered!");
      Room standup = new Room("stand up for your self", "You puff your chest out and begin argue back. She can tell you're weak! She takes the pizza's from you. Your manager fires you for stealing food! You Lose!!!");
      Room cry = new Room("cry", "You drop to the floor and begin to weap. The woman takes the pizza's from you and helps you out of her house.");
      Room returnCar = new Room("return to car", "You make it safely back to your car. It starts up and you drive off... But somethings wrong! The ride is terribly rough. You hear a loud grinding noise. Just as the house disappears behind the trees, your car comes to a halt. You get out to discover your tires were shredded off. They must've been slashed! Out from the bushes appears the Domino's noid. Yes, that noid. He does not tolerate failed deliveries. You're never heard from again.");
      Room followClown = new Room("out the window", "Like a loon, you jump out the window chasing after the clown. The follow it for sometime till you realize the clown is gone and you're all alone in the woods. Your phone is dead. Out the corner of your eyes you spot him. Actual cannibal Shia LaBeouf is now following you at 30 feet back. He gets on all fours and begins sprinting. He's gaining on you!");
      Room lastDoor = new Room("last door", "You open the door only to realize it was not a mirror, but rather a window. The old woman is standing on the other side. She draws her knife and quickly stabs you. As the world dims you watch as she walks off with your pizza, unable to stop her.");
      Room faceLady = new Room("fight old woman", "You go to turn when the woman grabs you from behind and sinks her rusty knife into your back. It's a sharp warm pain. You drop to the floor. As the world dims you watch as she walks off with your pizza, unable to stop her.");
      Room endTunnel = new Room("tunnel end", "You reach the end of the dark tunnel. You can make out 3-digit combo lock. But whats the combo?");


      AddRooms();
      BuildExits();
      CreateItems();

      void AddRooms()
      {
        Rooms.Add(start);
        Rooms.Add(knock);
        Rooms.Add(frontDoor);
        Rooms.Add(enterance);
        Rooms.Add(darkHall);
        Rooms.Add(shia);
        Rooms.Add(shia2);
        Rooms.Add(shia3);
        Rooms.Add(shiaDeath);
        Rooms.Add(puzzle);
        Rooms.Add(puzzleRight);
        Rooms.Add(puzzleWrong);
        Rooms.Add(chasmRoom);
        Rooms.Add(choiceRoom);
        Rooms.Add(chasmRoom2);
        Rooms.Add(choiceRoom);
        Rooms.Add(returnHall);
        Rooms.Add(emptyRoom);
        Rooms.Add(upStairs);
        Rooms.Add(scratchingRoom);
        Rooms.Add(approachArm);
        Rooms.Add(takeEnvelope);
        Rooms.Add(partyRoom);
        Rooms.Add(crazyMan);
        Rooms.Add(endHall);
        Rooms.Add(backHall);
        Rooms.Add(leftDoor);
        Rooms.Add(rightDoor);
        Rooms.Add(underDesk);
        Rooms.Add(playDead);
        Rooms.Add(continuePlayDead);
        Rooms.Add(darkTunnel);
        Rooms.Add(escapeTunnel);
        Rooms.Add(tunnelDoor);
        Rooms.Add(standup);
        Rooms.Add(cry);
        Rooms.Add(returnCar);
        Rooms.Add(followClown);
        Rooms.Add(lastDoor);
        Rooms.Add(faceLady);
        Rooms.Add(endTunnel);
      }

      void BuildExits()
      {
        start.AddExit("knock", knock);
        start.AddExit("return to car", returnCar);
        knock.AddExit("knock", frontDoor);
        knock.AddExit("return to car", returnCar);
        frontDoor.AddExit("return to car", returnCar);
        frontDoor.AddExit("enter house", enterance);
        enterance.AddExit("dark hallway", darkHall);
        enterance.AddExit("upstairs", upStairs);
        enterance.AddExit("door to right", emptyRoom);
        enterance.AddExit("return to car", returnCar);
        darkHall.AddExit("second door", shia);
        darkHall.AddExit("first door", puzzle);
        darkHall.AddExit("back", enterance);
        shia.AddExit("enter", shia2);
        shia.AddExit("back", darkHall);
        shia2.AddExit("stare back", shia3);
        shia2.AddExit("back", shiaDeath);
        shia3.AddExit("leave", darkHall);
        puzzle.AddExit("back", darkHall);
        puzzleWrong.AddExit("cross", chasmRoom);
        chasmRoom.AddExit("left door", choiceRoom);
        chasmRoom.AddExit("right door", returnHall);
        choiceRoom.AddExit("back", chasmRoom2);
        chasmRoom2.AddExit("enter", returnHall);
        returnHall.AddExit("enter", enterance);
        emptyRoom.AddExit("back", enterance);
        upStairs.AddExit("back", enterance);
        upStairs.AddExit("left", crazyMan);
        upStairs.AddExit("right", scratchingRoom);
        upStairs.AddExit("down hallway", endHall);
        crazyMan.AddExit("back", upStairs);
        crazyMan.AddExit("after clown", followClown);
        scratchingRoom.AddExit("back", upStairs);
        scratchingRoom.AddExit("towards arm", approachArm);
        approachArm.AddExit("back", upStairs);
        takeEnvelope.AddExit("to party room", partyRoom);
        takeEnvelope.AddExit("back", upStairs);
        endHall.AddExit("left", leftDoor);
        endHall.AddExit("right", rightDoor);
        endHall.AddExit("back", backHall);
        endHall.AddExit("forward", lastDoor);
        rightDoor.AddExit("under table", underDesk);
        rightDoor.AddExit("play dead", playDead);
        leftDoor.AddExit("back", endHall);
        playDead.AddExit("fight", faceLady);
        playDead.AddExit("contine playing dead", continuePlayDead);
        continuePlayDead.AddExit("after woman", faceLady);
        continuePlayDead.AddExit("toward tunnel", darkTunnel);
        darkTunnel.AddExit("back", faceLady);
        darkTunnel.AddExit("foward", endTunnel);
        endTunnel.AddExit("back", faceLady);
        tunnelDoor.AddExit("fight back", standup);
        tunnelDoor.AddExit("cry", cry);
      }
      void CreateItems()
      {
        Item flashlight = new Item("flashlight", "This might be helpful for finding secrets");
        Item glasses = new Item("glasses", "Your eyesight always did seem to hurt");
        Item envelope = new Item("envelope", "On the outside it reads 'Tip', but there doesn't appear to be any tip. It's just filled with 86 cents of assorted coins.");

        choiceRoom.Items.Add(flashlight);
        choiceRoom.Items.Add(glasses);
        approachArm.Items.Add(envelope);
      }
    }
  }
}