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
        private static int steps = 0;
        private ConsoleColor color = ConsoleColor.Blue;
        
        // Access Modifiers (Propertys)
        public static int CurPosX { get { return curPosX; } set { curPosX = value; } }
        public static int CurPosY { get { return curPosY; } set { curPosY = value; } }
        public static int OldPosX { get { return oldPosX; } set { oldPosX = value; } }
        public static int OldPosY { get { return oldPosY; } set { oldPosY = value; } }
        public string Icon { get { return icon; } set { value = icon; } }
        public static bool HasKey { get { return hasKey;} set { hasKey = value; }}
        public static int NumOfKeys { get { return numOfKeys; } set { numOfKeys = value;} }
        public static bool HasEscaped {  get{ return hasEscaped; } set{ hasEscaped = value; } }
        public static int Steps { get { return steps; } set { steps = value; } }
        public ConsoleColor Color { get { return color; } set { color = value;} }

        // Constructor
        public Player() : base()
        { }

        // Class Method
        public static void MovePlayer()
        {
            oldPosX = curPosX;
            oldPosY = curPosY;
            ConsoleKey move;
            move = Console.ReadKey(true).Key;
            switch (move)
            {
                case (ConsoleKey.W):
                    curPosY -= 1;
                    break;
                case (ConsoleKey.S):
                    curPosY += 1;
                    break;
                case (ConsoleKey.A):
                    curPosX -= 1;
                    break;
                case (ConsoleKey.D):
                    curPosX += 1;
                    break;
            }
            if (curPosX != oldPosX || curPosY != oldPosY)
                Steps += 1;

            Program.CollitionDetection(curPosY, curPosX);
            
            Program.map[oldPosY, oldPosX] = new Room();
            Program.map[curPosY, curPosX] = new Player();
        }
    }
}

