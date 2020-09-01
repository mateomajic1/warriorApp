﻿using System;
using System.Collections.Generic;

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

            bool alive = true;

            while (battle)
            {
                Random random1 = new Random();

                var num = random1.Next(1, 3);

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

                alive = checkAlive(warrior1);

                Console.WriteLine($"{warrior1.WarriorName} attacked and dealt {damage} points of damage");

                if (!alive)
                {
                    break;
                }

                alive = true;
                Random random2 = new Random();
                int damage2 = 0;

                var num2 =random2.Next(1, 3);

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

                Console.WriteLine($"{warrior2.WarriorName} attacked and dealt {damage2} points of damage");

                alive = checkAlive(warrior2);

                if (!alive)
                {
                    break;
                }
            }

            Warrior winner;

            if (warrior1.WarriorHealth > 0)
            {
                winner = warrior1;
            }
            else
            {
                winner = warrior2;
            }

            return winner;
        }

        public static bool checkAlive(Warrior warrior)
        {
            bool alive = true;

            if (warrior.WarriorHealth > 0)
            {
                alive = true;
            }
            else
            {
                alive = false;
            }

            return alive;
        }
    }
}