using Newtonsoft.Json;

namespace WorldofWarcraft
{
    public abstract class Entity
    {
        public string Name { get; set; }

        public virtual int Health { get; set; }

        public int Level { get; set; }

        public Race Race { get; set; }

        public virtual int Damage { get; set; }

        [JsonIgnore]
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        protected Entity(string name, Race race)
        {
            Name = name;
            Race = race;
        }

        public virtual void Attack(Entity entity)
        {
            entity.Health -= Damage;
        }
    }
}
