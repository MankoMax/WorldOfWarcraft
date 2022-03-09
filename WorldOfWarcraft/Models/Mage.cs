namespace WorldofWarcraft.Models
{
    public class Mage : Character
    {
        public override int Damage
        {
            get => base.Damage += Intellect;
            set => base.Damage = value;
        }

        public Mage(string name, Race race, CharacterType characterType)
             : base(name, race, characterType)
        {
        }
    }
}
