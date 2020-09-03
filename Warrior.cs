using System;
using System.Collections.Generic;

namespace warriorApp
{
    internal class Warrior : IWarrior
    {
        public string WarriorName { get; set; }
        public int WarriorHealth { get; set; }
        public WeaponType WeaponType { get; set; }

        public Warrior(string warriorName, int warriorHealth, WeaponType weaponType)
        {
            WarriorHealth = warriorHealth;
            WarriorName = warriorName;
            WeaponType = weaponType;
        }

        public Warrior()
        {
        }

        public void ListAllWarriors(List<Warrior> warriors)
        {
            foreach (var warrior in warriors)
            {
                Console.WriteLine($"{warrior.WarriorName} ima {warrior.WarriorHealth} hp");
            }
        }
    }
}