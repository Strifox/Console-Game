using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Score
    {
        private static int curScore = 0;
        private static int maxScore = curScore;
        
        public static int CurScore { get { return curScore; } set { curScore = value; } }
        public static int MaxScore { get { return maxScore; } set { maxScore = value; } }

        public Score()
        { }
    }
}
