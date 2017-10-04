using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class Combat
    {
        private const string WRONGINPUT = "Wrong Input";

        public static void CombatSystem(MonsterRoom enemy)
        {

            while (enemy.isAlive && Player.isAlive)
            {
                Console.WriteLine($"Your health is {Player.playerHealthPoints}");
                Console.WriteLine($"The {enemy.Name}s health is {enemy.EnemyHealthPoints}");
                Console.WriteLine("Press on '1' to attack");

                var fight = Console.ReadKey();
                Console.Clear();
                Random enemyHit = new Random();
                int randomEnemyHit = enemyHit.Next(1, enemy.EnemyAttack);

                // If-else statement with random generators to our combat system
                if (fight.Key == ConsoleKey.NumPad1 || fight.Key == ConsoleKey.D1)
                {
                    Random meleeDamage = new Random();
                    int randomMeleeDamage = meleeDamage.Next(1, Player.playerAttack);

                    if (randomMeleeDamage < 10)
                    {
                        Console.WriteLine($"The {enemy.Name} hit you for {randomEnemyHit} damage!");
                        Player.playerHealthPoints -= randomEnemyHit;
                        Console.WriteLine($"You hit the {enemy.Name} for {randomMeleeDamage} damage!");
                        enemy.EnemyHealthPoints -= randomMeleeDamage;
                    }
                    else
                    {
                        Console.WriteLine($"The {enemy.Name} hit you for {randomEnemyHit} damage!");
                        Player.playerHealthPoints -= randomEnemyHit;
                        Console.WriteLine($"You critically hit {enemy.Name} for {randomMeleeDamage} damage!");
                        enemy.EnemyHealthPoints -= randomMeleeDamage;
                    }

                }
                // If statement in case of pressing the wrong button.
                if (fight.Key != ConsoleKey.NumPad1 && fight.Key != ConsoleKey.D1)
                    Console.WriteLine(WRONGINPUT);

                // else-if statements if Player or enemy dies
                else if (enemy.EnemyHealthPoints <= 0)
                {
                    enemy.isAlive = false;
                    Console.WriteLine($"You have killed the {enemy.Name}");
                    Player.score += enemy.ScoreGained;
                    
                }
                else if (Player.playerHealthPoints <= 0)
                {
                    Player.isAlive = false;
                    Console.WriteLine("You died!");
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                }
            }
        }
    }
}
