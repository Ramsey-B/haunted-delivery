using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public List<Room> Rooms { get; set; }
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

    public void UseItem(string itemName)
    {

    }

    public void CreateRooms()
    {
      Room knock = new Room("knock", "You approach the door and knock. There's no answer. The only noise is some russling in the bushes...");
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
      Room crazyMan = new Room("laughing room", "Immediately as the door opens, water begins pouring out and flooding the hallway. It smells awful. At first there doesnt seem to be a source to the laughter. But suddenly, a figure rises from a pool of water in the center of the room. It's a birthday clown. He appears to have been attacked by some pack of wolves! He quickly runs and jumps out a window, sreaming wildly.");
      Room endHall = new Room("end of hallway", "At the end of a hallway is a door with a mirror. Foolishly you look into the mirror. In it, you notice a tall, boney woman standing at the top of the stairs. Shes looking straight at you. Her eyes open wider than you thought possible. Shes brandishing an old rusty knife. To your left and right are two doors. To the right a seemingly normal door. To the left, is a slightly cracked open door, inside you chains, knives, and hooks hanging on the wall.");
      Room backHall = new Room("go back to stairs", "Like a true hero, you turn to face the woman, but shes gone... cause obviously... The door now behind you swings open and the woman you saw before jams the knife into you. As the world goes dim, you watch helplessly as she takes the pizza.");
      Room leftDoor = new Room("clock room", "You open the door to find a room full of clocks... The ticking is maddening... The clocks are hard to read because your intellect is low. Something seems off about this room... It's dark and hard to see. One clock stands out though... If only you could read it.");
      Room rightDoor = new Room("murder room", "As you might've guessed, this reeks of death. Outside door hear footsteps. You could grab a weapon, but those are against Domino's policy! Your only choice is to hide.");
      Room underDesk = new Room("under desk", "Under the desk you can only see a couple inches off the floor. A figure walks in, but you can only see their bare, grey feet... They wait some time before leaving.");
      Room playDead = new Room("play dead", "A drop to the floor like a dead fish. The woman enters the room and looks at you for sometime. She then picks you up by the ankles and drags you off");
      Room continuePlayDead = new Room("keeping play dead", "She drags you into the mirrored door room. You can now see that it was not a mirror, but rather a window. She then chucks you onto a pile of bodies and leaves. You can follow her, but you also spot a dark smelly hole in the wall.");
      Room darkTunnel = new Room("dark tunnel", "You shuffle over the bodies into the dark tunnel. It's pitch black.");
      Room escapeTunnel = new Room("escape tunnel", "You push on the crack. It bursts open sending you plummeting to the ground outside. You're free! Or so you thought. Now youre all alone in the woods. Your phone is dead. Out the corner of your eyes you spot him. Actual cannibal Shia LaBeouf is now following you at 30 feet back. He gets on all fours and begins sprinting. He's gaining on you!");
      Room tunnelDoor = new Room("tunnel door", "You open the door. You walk in and find a empty table in an otherwise empty room. The door shuts behind you, but you didn't shut it! You turn to discover a soccer mom! She begins yelling! 'Its been over 30 minutes! My food should be free!'. You look at the ticket but notice its only been 25 minutes since she ordered!");
      Room standup = new Room("stand up for your self", "You puff your chest out and begin argue back. She can tell you're weak! She takes the pizza's from you. Your manager fires you for stealing food! You Lose!!!");
      Room cry = new Room("cry", "You drop to the floor and begin to weap. The woman takes the pizza's from you and helps you out of her house.");
      Room returnCar = new Room("return to car", "You make it safely back to your car. It starts up and you drive off... But somethings wrong! The ride is terribly rough. You hear a loud grinding noise. Just as the house disappears behind the trees, your car comes to a halt. You get out to discover your tires were shredded off. They must've been slashed! Out from the bushes appears the Domino's noid. Yes, that noid. He does not tolerate failed deliveries. You're never heard from again.");

      AddRooms();
      BuildExits();

      void AddRooms()
      {
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
      }

      void BuildExits()
      {
        knock.AddExit("knock", frontDoor);
        knock.AddExit("return to car", returnCar);
        frontDoor.AddExit("reurn to car", returnCar);
        frontDoor.AddExit("enter house", enterance);
        enterance.AddExit("dark hallway", darkHall);
        enterance.AddExit("upstairs", upStairs);
        enterance.AddExit("door to right", emptyRoom);
        enterance.AddExit("reurn to car", returnCar);
        darkHall.AddExit("second door", shia);
        darkHall.AddExit("first door", puzzle);
        darkHall.AddExit("return to enterance", enterance);
        shia.AddExit("second room", shia2);
        shia.AddExit("back", darkHall);
        shia2.AddExit("in room", shia3);
        shia2.AddExit("back", shiaDeath);
        puzzle.AddExit("back", darkHall);
        puzzleWrong.AddExit("across", chasmRoom);
        chasmRoom.AddExit("left door", choiceRoom);
        chasmRoom.AddExit("right door", returnHall);
        choiceRoom.AddExit("back", chasmRoom2);
        returnHall.AddExit("back", enterance);
returnHall
emptyRoom
upStairs
scratchingRoom
approachArm
takeEnvelope
partyRoom
crazyMan
endHall
backHall
leftDoor
rightDoor
underDesk
playDead
continuePlayDead
darkTunnel
escapeTunnel
tunnelDoor
standup
cry
      }
    }
  }
}