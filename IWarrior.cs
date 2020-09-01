using System.Collections.Generic;

namespace warriorApp
{
    internal interface IWarrior
    {
        public void ListAllWarriors(List<Warrior> warriors);

        public string WarriorName { get; set; }
        public int WarriorHealth { get; set; }
    }
}