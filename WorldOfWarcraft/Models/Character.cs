namespace WorldOfWarcraft
{
    public abstract class Character : Entity
    {
        public int Stamina { get; set; }

        public int Strenghth { get; set; }

        public int Intellect { get; set; }

        public Character(string name, int health, int level, int stamina, int strenghth, int intellect, Race race, int damage)
            : base(name, health, level, race, damage)
        {
            Stamina = stamina;
            Strenghth = strenghth;
            Intellect = intellect;
        }
    }
}
