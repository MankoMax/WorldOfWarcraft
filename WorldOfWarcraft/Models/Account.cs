using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WorldOfWarcraft.Repositories
{
    public class Account
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid Id { get; set; }

        [JsonIgnore]
        public List<Character> Characters
        {
            get
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + @$"AccountBase\{Id}.json";
                var charactersJson = File.ReadAllText(path);

                if (string.IsNullOrEmpty(charactersJson))
                {
                    return new List<Character>();
                }
                else
                {
                    return JsonConvert.DeserializeObject<List<Character>>(charactersJson);
                }
            }
        }

        public Account()
        {
            Id = Guid.NewGuid();
        }
    }
}
