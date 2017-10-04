using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class Orc : MonsterRoom
    {
        public Orc(int enemyHealthPoints, int enemyAttack) : base()
        {
            this.EnemyHealthPoints = enemyHealthPoints;
            this.EnemyAttack = enemyAttack;
            Name = "Orc";
            ScoreGained = 75;
        }
    }
}
