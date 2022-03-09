using WorldofWarcraft.Models;

namespace WorldofWarcraft
{
    public class Character : Entity
    {
        public int Stamina { get; set; }

        public int Strenghth { get; set; }

        public int Intellect { get; set; }

        public override int Health 
        { 
            get => base.Health += Stamina * 2; 
            set => base.Health = value; 
        }

        public CharacterType CharacterType { get; set; }

        public Character(string name, Race race, CharacterType characterType)
            : base(name, race)
        {
            CharacterType = characterType;
        }

        public override string ToString()
        {
            return $"Class: {CharacterType} \nRace: {Race} \nName: {Name}" +
                    $"\nLevel: {Level} \n";
        }
    }
}
