using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        public static IGraphic[,] map = new IGraphic[8, 20]; // Skapar spelkartan, datatyp 'Interface'
        public static int mapLengthX = map.GetLength(1) - 1;
        public static int mapLengthY = map.GetLength(0) - 1;
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


            map[5, 3] = new MonsterRoom();
            map[4, 5] = new MonsterRoom();
            map[6, 11] = new MonsterRoom();
            map[2, 12] = new MonsterRoom();
            map[1, 5] = new MonsterRoom();


            map[6, 2] = new KeyRoom();
            map[5, 8] = new KeyRoom();
            map[1, 17] = new KeyRoom();
            map[4, 12] = new KeyRoom();

            map[1, 2] = new ExitDoor();

            map[Player.CurPosY, Player.CurPosX] = new Player();

            curGameState = GameStates.intro;
            curLevelState = LevelStates.level1;

            // Start of Game Loop
            while (curGameState != GameStates.exit && !Player.HasEscaped)
            {
                Console.SetCursorPosition(0, 0);

                switch (curGameState)
                {
                    case GameStates.intro:
                        Console.SetCursorPosition(Console.WindowWidth / 3, Console.WindowHeight / 2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your goal is to exit the map as fast as possible!");
                        Console.ReadKey();
                        Console.Clear();
                        curGameState = GameStates.ingame;
                        break;
                }
                switch (curGameState)
                {
                    case GameStates.ingame:
                        switch (curLevelState)
                        {
                            case LevelStates.level1:
                                PrintMap(map);
                                Console.WriteLine($"Keys: {Player.NumOfKeys}");
                                Console.WriteLine($"Steps: {Player.Steps}");
                                //Console.SetCursorPosition(Console.WindowWidth / 2, 0);                       
                                Player.MovePlayer();
                                break;
                        }
                        break;
                }
            } // End of Game Loop!
        }
        // Skriver ut kartan och alla objekt på consolen.
        private static void PrintMap(IGraphic[,] map)
        {
            //string tempMap = "";
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
                        else
                            Player.HasKey = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDoor is locked!");
                        Player.Steps -= 1;
                        Player.CurPosX = Player.OldPosX;
                        Player.CurPosY = Player.OldPosY;
                    }
                    Console.ReadKey();
                    break;
                case ("M"):
                    Console.WriteLine("\nEntered Monster Room!\nYou are stuck\n+5 Steps!");
                    Player.Steps += 5;

                    Console.ReadKey();
                    break;
                case ("k"):
                    Console.WriteLine("\nYou entered a room and found a key!");
                    Player.NumOfKeys += 1;
                    Player.HasKey = true;

                    Console.ReadKey();
                    break;
                case ("#"):
                    Player.Steps -= 1;
                    Player.CurPosX = Player.OldPosX;
                    Player.CurPosY = Player.OldPosY;

                    break;
                case ("E"):
                    Console.Clear();
                    Console.WriteLine("\nYOU ESCAPED!");
                    Player.HasEscaped = true;
                    Console.ReadKey();
                    break;
            }
        }
    }
}
