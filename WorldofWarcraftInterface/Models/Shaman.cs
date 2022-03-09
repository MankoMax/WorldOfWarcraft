namespace WorldofWarcraft.Models
{
    public class Shaman : Character
    {
        public override int Damage
        {
            get => base.Damage += (Strenghth + Intellect) / 2;
            set => base.Damage = value;
        }

        public Shaman(string name, Race race, CharacterType characterType)
             : base(name, race, characterType)
        {
        }
    }
}
