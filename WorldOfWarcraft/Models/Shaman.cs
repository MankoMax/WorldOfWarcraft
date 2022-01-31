namespace WorldOfWarcraft.Models
{
    public class Shaman : Character
    {
        public Shaman(string name, int health, int level, int stamina, int strenghth, int intellect, Race race, int damage)
            : base(name, health, level, stamina, strenghth, intellect, race, damage)
        {
        }

        protected override void Attack(Entity entity)
        {
            entity.Health -= (Damage * (Strenghth + Intellect)) / 2;
        }
    }
}
