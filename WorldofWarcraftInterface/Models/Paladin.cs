using WorldofWarcraft.Models;

namespace WorldofWarcraft
{
    public class Paladin : Character
    {
        public override int Damage 
        { 
            get => base.Damage += Strenghth; 
            set => base.Damage = value; 
        }

        public Paladin(string name, Race race, CharacterType characterType)
             : base(name, race, characterType)
        {
        }
    }
}
