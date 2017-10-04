using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO
namespace Lab4
{
    class Program
    {
        public static Board[,] map = new Board[8, 20]; // Skapar spelkartan, datatyp 'Interface'
        public static int mapLengthX = map.GetLength(1) - 1;
        public static int mapLengthY = map.GetLength(0) - 1;
        public enum LevelStates
        {
            level1
        }
        public enum GameStates
        {
            start,
            exit
        }
        private static GameStates curGameState;
        private static LevelStates curLevelState;

        static void Main(string[] args)
        {
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


            map[5, 3] = new Goblin(50, 10);
            map[4, 5] = new Goblin(50, 10);
            map[6, 11] = new Goblin(50, 10);
            map[2, 12] = new Orc(70, 15);
            map[1, 5] = new Orc(70, 15);

            map[6, 2] = new KeyRoom();
            map[5, 8] = new KeyRoom();
            map[1, 17] = new KeyRoom();
            map[4, 12] = new KeyRoom();

            map[1, 2] = new ExitDoor();

            map[Player.CurPosY, Player.CurPosX] = new Player();

            curGameState = GameStates.start;
            curLevelState = LevelStates.level1;

            // Beginning of Game loop
            while (curGameState != GameStates.exit && !Player.HasEscaped && Player.isAlive)
            {
                switch (curLevelState)
                {
                    case (LevelStates.level1):
                        Console.Clear();
                        PrintMap(map);
                        Console.WriteLine($"Keys: {Player.NumOfKeys}");
                        Console.WriteLine($"Steps: {Player.steps}");
                        Console.WriteLine($"Score: {Player.score}");
                        Console.WriteLine($"Health: {Player.playerHealthPoints}");
                        //Console.SetCursorPosition(Console.WindowWidth / 2, 0);                       
                        Player.MovePlayer();
                        break;
                }
            } // End of Game loop!
        }

        public static void PrintMap(Board[,] map)
        {
            // string tempMap = "";
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    //tempMap
                    Console.ForegroundColor = map[y, x].Color;
                    Console.Write(map[y, x].Icon);

                }
                //tempMap += Environment.NewLine;
                Console.WriteLine("");
            }
            //Console.WriteLine(tempMap);

        }
        public static void CollitionDetection(int playerPosY, int playerPosX)
        {

            switch (map[playerPosY, playerPosX].Icon)
            {
                case ("D"):
                    Door.DoorInteraction();
                    if (!Door.IsLocked)
                    {
                        Console.WriteLine("\nUnlocked door!");
                        Player.NumOfKeys -= 1;
                        if (Player.NumOfKeys <= 0)
                            Player.HasKey = false;
                    }
                    else
                    {
                        Console.WriteLine("\nDoor is locked!");
                        Player.CurPosX = Player.OldPosX;
                        Player.CurPosY = Player.OldPosY;
                    }
                    Console.ReadKey();
                    break;
                case ("M"):
                    Console.WriteLine("\nEntered Monster Room!\nYou loose x points");
                    Console.ReadKey();
                    Combat.CombatSystem((MonsterRoom)map[playerPosY, playerPosX]);
                    break;
                case ("K"):
                    Console.WriteLine("\nYou entered a room and found a key!");
                    Player.NumOfKeys += 1;
                    Player.HasKey = true;

                    Console.ReadKey();
                    break;
                case ("#"):
                    Player.steps--;
                    Player.CurPosX = Player.OldPosX;
                    Player.CurPosY = Player.OldPosY;

                    break;
                case ("E"):
                    Console.Clear();
                    Console.WriteLine("YOU ESCAPED!");
                    Console.WriteLine($"Your score is: {Player.finalScore = Player.score - Player.steps}");
                    Player.HasEscaped = true;
                    Console.ReadKey();
                    break;
            }
        }
    }
}