namespace WorldOfWarcraft
{
    public abstract class Entity
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Level { get; set; }

        public Race Race { get; set; }

        public int Damage { get; set; }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        protected Entity(string name, int health, int level, Race race, int damage)
        {
            Name = name;
            Health = health;
            Level = level;
            Race = race;
            Damage = damage;
        }

        protected virtual void Attack(Entity entity)
        {
            entity.Health -= Damage;
        }
    }
}
