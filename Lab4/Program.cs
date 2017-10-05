using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
{
    // ----------------------<<<<<<< HIGHSCORE : 
    class Program
    {   
        public static Sword sword = new Sword();
        public static KeyRoom superkey = new KeyRoom(2);
        public static Shield shield = new Shield();
        public static Board[,] map = new Board[8, 20]; // Skapar spelkartan, datatyp 'Board(Base-Class)'
        public static int mapLengthX = map.GetLength(1) - 1;
        public static int mapLengthY = map.GetLength(0) - 1;
        private static string lastAction;
        public static string LastAction { get { return lastAction; } set { lastAction = value; } } //Method to minimize the text used

        public enum LevelStates
        {
            level1
        }
        public enum GameStates
        {
            intro,
            ingame,
            exit
        }
        private static GameStates curGameState;
        private static LevelStates curLevelState;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            // Initierar spelkartan och lägger till väggarna samt "korridorer"
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (y >= 1 && y <= 2 && x == 10)
                        map[y, x] = new Wall();
                    else if (y == 0 || y == mapLengthY)
                        map[y, x] = new Wall();
                    else if (x == 14 && y <= 6 && y > 3)
                        map[y, x] = new Wall();
                    else if (x == 0 || x == mapLengthX)
                        map[y, x] = new Wall();
                    else if (x >= 0 && y == 3)
                        map[y, x] = new Wall();
                    else if ((y >= 4 && y <= 6) && x == 7)
                        map[y, x] = new Wall();
                    else
                        map[y, x] = new Room();
                }
            }
            // Lägger till ytterligare objekt i 2d arrayen 'map' (Dörrar, Speciella rum etc.)
            map[4, 7] = new Door();
            map[6, 14] = new Door();
            map[1, 10] = new Door();
            map[3, 17] = new Door();

            map[2, 15] = new Trap();
            map[2, 2] = new Trap();
            map[5, 15] = new Trap();

            map[5, 3] = new Goblin(50, 10);
            map[4, 5] = new Goblin(50, 10);
            map[6, 11] = new Goblin(50, 10);
            map[2, 12] = new Orc(70, 15);
            map[1, 5] = new Orc(70, 15);

            map[6, 2] = new KeyRoom(1);
            map[5, 8] = new KeyRoom(2);
            map[1, 17] = new KeyRoom(1);
            map[4, 12] = new KeyRoom(1);

            map[5, 10] = new Sword();

            map[4, 1] = new Shield();

            map[1, 2] = new ExitDoor();

            map[Player.CurPosY, Player.CurPosX] = new Player();

            curGameState = GameStates.intro;
            curLevelState = LevelStates.level1;
            
            // Beginning of Game loop
            while (curGameState != GameStates.exit && !Player.HasEscaped && Player.isAlive)
            {
                // rensa 
                
                Console.SetCursorPosition(0, 0);
                

                switch (curGameState)
                {
                    case GameStates.intro:
                        Console.SetCursorPosition(Console.WindowWidth / 7, Console.WindowHeight / 2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your goal is to escape with as few steps as possible and slay monsters for score boost");
                        Console.ReadKey();
                        curGameState = GameStates.ingame;
                        Console.Clear();
                        break;

                    case GameStates.ingame:
                        switch (curLevelState)
                        {
                            case LevelStates.level1:
                                //Console.Clear();
                                PrintMap(map);
                                Console.WriteLine($"Keys: {Player.NumOfKeys}");
                                Console.WriteLine($"SuperKey: {Player.numOfSuperkeys}");
                                Console.WriteLine($"Steps: {Player.steps}");
                                Console.WriteLine($"Score: {Player.score}");
                                Console.WriteLine($"Health: {Player.playerHealthPoints}");
                                Console.WriteLine($"Attack Dmg: {Player.playerAttack}");
                                Console.WriteLine(LastAction);
                                Player.MovePlayer();
                                break;
                        }
                        break;
                }
            } // End of Game loop!
        }

        //Initiate invisible 2D array map with only walls visible at first
        public static void PrintMap(Board[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (y < Player.CurPosY + 2 && y > Player.CurPosY - 2
                        && x < Player.CurPosX + 2 && x > Player.CurPosX - 2)
                    {
                        if (!map[y, x].TileExplored)
                            map[y, x].TileExplored = true;

                    }
                    if (map[y, x].TileExplored)
                    {
                        Console.ForegroundColor = map[y, x].Color;
                        Console.Write(map[y, x].Icon);
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("");
            }
            //Debug.DebugExploreMap();  //Debug Method
        }
        public static void CollitionDetection(int playerPosY, int playerPosX)
        {

            switch (map[playerPosY, playerPosX].Icon)
            {
                case ("D"):
                    Door.DoorInteraction();
                    if (!Door.IsLocked)
                    {
                        ConsoleKey option;
                        do
                        {
                            Console.Clear(); 
                            Console.WriteLine("What key to use?\n1 - 'Key'\n2 - 'Superkey'");
                            option = Console.ReadKey().Key;
                            switch (option)
                            {
                                case ConsoleKey.D1:
                                    if (Player.HasKey)
                                    {
                                        Player.NumOfKeys -= 1;
                                        if (Player.NumOfKeys <= 0) { }
                                        Player.HasKey = false;
                                        LastAction = "\nUsed Key";
                                    }
                                    else
                                    {
                                        Player.CurPosX = Player.OldPosX;
                                        Player.CurPosY = Player.OldPosY;
                                        LastAction = "\nYou dont have the required key!";
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    if (Player.hasSuperKey)
                                    {
                                        superkey.Durability -= 1;
                                        superkey.CheckDurability();
                                        LastAction = "\nUsed Superkey";
                                    }
                                    else
                                    {
                                        Player.CurPosX = Player.OldPosX;
                                        Player.CurPosY = Player.OldPosY;
                                        LastAction = "\nYou dont have the required key!";

                                    }
                                    break;
                                default:
                                    LastAction = "\nWrong input!";
                                    break;
                            }

                        } while (option != ConsoleKey.D1 && option != ConsoleKey.D2);
                    }
                    else
                    {
                        LastAction = "\nDoor is locked!";
                        Player.CurPosX = Player.OldPosX;
                        Player.CurPosY = Player.OldPosY;
                    }
                    //Console.ReadKey();
                    break;
                case ("M"):
                    LastAction = "\nYou entered a Monster Room!";
                    Console.WriteLine(LastAction);
                    Combat.CombatSystem((MonsterRoom)map[playerPosY, playerPosX]);
                    Console.Clear();
                    break;
                case ("K"):
                    if (map[playerPosY, playerPosX] == map[5, 8])
                    {
                        Player.numOfSuperkeys += 1;
                        LastAction = "\nYou found a super key";
                        Player.hasSuperKey = true;
                    }
                    else
                    {
                        Player.NumOfKeys += 1;
                        LastAction = "\nYou entered a room and found a key!";
                        Player.HasKey = true;
                    }
                    //Console.ReadKey();
                    break;
                case ("#"):
                    Player.steps--;
                    Player.CurPosX = Player.OldPosX;
                    Player.CurPosY = Player.OldPosY;
                    break;
                case ("$"):
                    Sword sword = new Sword();
                    Player.hasSword = true;
                    sword.ExtraAttackDamage();
                    LastAction = "\nYou found a sword and gained +10 attack damage";
                    //Console.ReadKey();
                    break;
                case ("¤"):
                    Shield shield = new Shield();
                    Player.hasShield = true;
                    shield.HealthBoost();
                    LastAction = "\nYou found a Shield and gained +20 health points";
                    //Console.ReadKey();
                    break;
                case ("T"):
                    Trap trap = (Trap)map[playerPosY, playerPosX];
                    LastAction = "\nYou have stepped on a trap! You gained +8 extra steps";
                    Player.steps += 8;
                    //Console.ReadKey();
                    break;
                case ("E"):
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("YOU ESCAPED!\n");
                    Player.finalScore = Player.score - Player.steps;
                    Console.Write($"Your score is: {Player.finalScore}");
                    Console.ReadKey();
                    Player.HasEscaped = true;
                    //Console.ReadKey();
                    break;
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
        
}
