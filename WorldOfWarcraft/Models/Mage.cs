namespace WorldOfWarcraft.Models
{
    public class Mage : Character
    {
        public Mage(string name, int health, int level, int stamina, int strenghth, int intellect, Race race, int damage)
            : base(name, health, level, stamina, strenghth, intellect, race, damage)
        {
        }

        protected override void Attack(Entity entity)
        {
            entity.Health -= (Damage * Intellect);
        }
    }
}
