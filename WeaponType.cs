namespace warriorApp
{
    internal class WeaponType
    {
        public Sword Sword { get; set; }
        public Spear Spear { get; set; }
        public Hammer Hammer { get; set; }

        public WeaponType(Sword sword, Spear spear, Hammer hammer)
        {
            Sword = sword;
            Spear = spear;
            Hammer = hammer;
        }
    }
}