using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class Goblin : MonsterRoom
    {
       
        public Goblin(int enemyHealthPoints, int enemyAttack) : base()
        {
            EnemyHealthPoints = enemyHealthPoints;
            EnemyAttack = enemyAttack;
            Name = "Goblin";
            ScoreGained = 50;
        }

    }
}
