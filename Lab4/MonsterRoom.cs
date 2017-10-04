using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class MonsterRoom : Room
    {
        // Combat system ints
        private int enemyHealthPoints = 0;
        private int enemyAttack = 0;
        private int scoreGained = 0;
        public string name;
        public bool isAlive = true;
        public int ScoreGained { get { return scoreGained; } set { scoreGained = value; } }
        public int EnemyHealthPoints { get { return enemyHealthPoints; } set { enemyHealthPoints = value; } }
        public int EnemyAttack { get { return enemyAttack; } set { enemyAttack = value; } }
        public string Name { get { return name; } set { name = value; } }

        private string icon = "M";

        public override string Icon { get { return icon; } set { value = icon; } }
        public bool hasMonster = true;

        public MonsterRoom() : base()
        { }
    }
}
