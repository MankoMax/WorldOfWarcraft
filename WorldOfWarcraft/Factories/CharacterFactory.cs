using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WorldOfWarcraft.Models;

namespace WorldOfWarcraft.Repository
{
    public class CharacterFactory
    {
        public Character Create(string name, Race race, CharacterType characterType)
        {
            Character character = null;

            var statsFolder = AppDomain.CurrentDomain.BaseDirectory + @"Stats\";
            var settingsPath = statsFolder + characterType + ".json";

            switch (characterType)
            {
                case CharacterType.Paladin:

                    character = new Paladin(name, race, characterType);

                    break;

                case CharacterType.Mage:

                    character = new Mage(name, race, characterType);

                    break;

                case CharacterType.Shaman:

                    character = new Shaman(name, race, characterType);

                    break;
            }

            var stats = DeserializeCharacterStats(settingsPath);

            character.Stamina = stats.Stamina;
            character.Strenghth = stats.Strenghth;
            character.Intellect = stats.Intellect;
            character.Level = stats.Level;
            character.Health = stats.Health;
            character.Damage = stats.Damage;

            return character;
        }

        private Stats DeserializeCharacterStats(string path)
        {
            return JsonConvert.DeserializeObject<Stats>(File.ReadAllText(path));
        }
    }
}