using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Player : Board
    {
        // Private fields
        private static bool hasEscaped = false;
        private static int numOfKeys = 0;
        private static bool hasKey = false;
        private static int curPosX = 5;
        private static int curPosY = 6;
        private static int oldPosX;
        private static int oldPosY;
        private string icon = "@";
        private ConsoleColor color = ConsoleColor.Blue;
        // Public Fields
        public static bool hasSuperKey = false;
        public static int playerAttack = 20;
        public static int playerHealthPoints = 100;
        public static bool isAlive = true;
        public static int steps = 0;
        public static int score = 0;
        public static int finalScore = 0;
        public static bool hasSword = false;
        public static int numOfSuperkeys = 0;

        // Access Modifiers (Propertys)
        public static int CurPosX { get { return curPosX; } set { curPosX = value; } }
        public static int CurPosY { get { return curPosY; } set { curPosY = value; } }
        public static int OldPosX { get { return oldPosX; } set { oldPosX = value; } }
        public static int OldPosY { get { return oldPosY; } set { oldPosY = value; } }
        public override string Icon { get { return icon; } set { value = icon; } }
        public static bool HasKey { get { return hasKey; } set { hasKey = value; } }
        public static int NumOfKeys { get { return numOfKeys; } set { numOfKeys = value; } }
        public static bool HasEscaped { get { return hasEscaped; } set { hasEscaped = value; } }

        public override ConsoleColor Color { get { return color; } set { color = value; } }

        // Constructor
        public Player() : base()
        { }

        // Instance Method
        public static void MovePlayer()
        {
            oldPosX = curPosX;
            oldPosY = curPosY;
            //ConsoleKey move;
            //move = Console.ReadKey().Key;
            var move = Console.ReadKey(true);
            if (move.Key == ConsoleKey.W)
                curPosY -= 1;
            else if (move.Key == ConsoleKey.A)
                curPosX -= 1;
            else if (move.Key == ConsoleKey.S)
                curPosY += 1;
            else if (move.Key == ConsoleKey.D)
                curPosX += 1;

            if (curPosX != oldPosX || curPosY != oldPosY)
                steps += 1;

            Program.CollitionDetection(curPosY, curPosX);

            Program.map[oldPosY, oldPosX] = new Room();
            Program.map[curPosY, curPosX] = new Player();
        }
    }
}

