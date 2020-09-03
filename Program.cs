using System;
using System.Collections.Generic;
using System.Threading;

namespace warriorApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rng = new Random();
            List<Warrior> warriors = new List<Warrior>();

            var sword = new Sword(rng.Next(11, 19));
            var spear = new Spear(rng.Next(11, 19));
            var hammer = new Hammer(rng.Next(11, 19));

            var weaponType = new WeaponType(sword, spear, hammer);

            for (int i = 0; i < 5; i++)
            {
                var hp = rng.Next(90, 100);
                string warriorName = "Sime" + i.ToString();

                var warrior = new Warrior(warriorName, hp, weaponType);
                warriors.Add(warrior);
            }

            Console.WriteLine("Starting battle...");

            var warIdx = rng.Next(warriors.Count);
            var warrior1 = warriors[warIdx];

            var warIdx2 = rng.Next(warriors.Count);
            var warrior2 = warriors[warIdx2];

            var winner = StartBattle(warrior1, warrior2);

            Console.WriteLine($"The winner is {winner.WarriorName} with {winner.WarriorHealth} hp left");
        }

        public static Warrior StartBattle(Warrior warrior1, Warrior warrior2)
        {
            bool battle = true;
            var random = new Random();

            while (battle)
            {
                Random random1 = new Random();
                var num = random1.Next(1, 3);
                bool alive;
                int damage = 0;

                switch (num)
                {
                    case 1:
                        damage = warrior1.WeaponType.Sword.WeaponStrength;
                        break;

                    case 2:
                        damage = warrior1.WeaponType.Spear.WeaponStrength;
                        break;

                    case 3:
                        damage = warrior1.WeaponType.Hammer.WeaponStrength;
                        break;
                }

                warrior1.WarriorHealth = warrior1.WarriorHealth - damage;

                if (warrior1.WarriorHealth < damage)
                {
                    warrior1.WarriorHealth = 0;

                    break;
                }

                alive = checkAlive(warrior1);

                if (!alive)
                {
                    break;
                }
                alive = checkAlive(warrior2);
                if (!alive)
                {
                    break;
                }
                Console.WriteLine($"{warrior1.WarriorName} attacked and dealt {damage} points of damage, {warrior1.WarriorName} has {warrior1.WarriorHealth} hp left");
                System.Threading.Thread.Sleep(1000);
                Random random2 = new Random();
                int damage2 = 0;

                var num2 = random2.Next(1, 3);

                switch (num2)
                {
                    case 1:
                        damage2 = warrior2.WeaponType.Sword.WeaponStrength;
                        break;

                    case 2:
                        damage2 = warrior2.WeaponType.Spear.WeaponStrength;
                        break;

                    case 3:
                        damage2 = warrior2.WeaponType.Hammer.WeaponStrength;
                        break;
                }

                warrior2.WarriorHealth = warrior2.WarriorHealth - damage2;

                if (warrior2.WarriorHealth < damage)
                {
                    warrior2.WarriorHealth = 0;

                    break;
                }

                alive = checkAlive(warrior2);

                if (!alive)
                {
                    break;
                }

                alive = checkAlive(warrior1);
                if (!alive)
                {
                    break;
                }

                Console.WriteLine($"{warrior2.WarriorName} attacked and dealt {damage2} points of damage, {warrior2.WarriorName} has {warrior2.WarriorHealth} hp left");
                System.Threading.Thread.Sleep(1000);
            }

            Warrior winner;

            if (warrior1.WarriorHealth == 0)
            {
                winner = warrior2;
            }
            else
            {
                winner = warrior1;
            }

            return winner;
        }

        public static bool checkAlive(Warrior warrior)
        {
            bool alive;

            if (warrior.WarriorHealth < 0 || warrior.WarriorHealth == 0)
            {
                alive = false;
            }
            else
            {
                alive = true;
            }

            return alive;
        }

        private static void slow()
        {
            int seconds = 5 * 10000;
            var timer = new Timer(TimerMethod, null, 0, seconds);
        }

        private static void TimerMethod(object o)
        {
            Console.WriteLine("Running" + DateTime.Now);
        }
    }
}