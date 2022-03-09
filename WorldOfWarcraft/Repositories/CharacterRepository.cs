using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WorldofWarcraft.Repositories
{
    public class CharacterRepository
    {
        public void CreateCharacter(Guid accountId, Character character)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @$"AccountBase\{accountId}.json";
            var charactersJson = File.ReadAllText(path);
            var characterList = new List<Character>();

            if (string.IsNullOrEmpty(charactersJson))
            {
                characterList = new List<Character>();
            }
            else
            {
                characterList = JsonConvert.DeserializeObject<List<Character>>(charactersJson);
            }

            characterList.Add(character);

            var serializedCharacters = JsonConvert.SerializeObject(characterList);

            File.WriteAllText(path, serializedCharacters);
        }
    }
}
