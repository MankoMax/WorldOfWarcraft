using System;
using WorldOfWarcraft.Models;

namespace WorldOfWarcraft.Managers
{
    public class GameManager
    {
        private ConsoleManager _consoleManager;

        public GameManager()
        {
            _consoleManager = new ConsoleManager();
        }
        public void StartGame()
        {
            var userInput = _consoleManager.ShowMenu();

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        CreateNewCharacter();

                        break;

                    case "2":
                        break;

                    case "3":
                        Environment.Exit(0);

                        break;

                    default:
                        _consoleManager.Clear();

                        break;
                }
            }
        }
        public void CreateNewCharacter()
        {
            _consoleManager.Clear();

            Console.WriteLine("1 - Paladin");
            Console.WriteLine("2 - Mage");
            Console.WriteLine("3 - Shaman");

            var input = _consoleManager.GetDataFromUser("\nChoose your character's CLASS: ");
            var health = 0;
            var level = 0;
            int stamina = 0;
            int strenghth = 0;
            int intellect = 0;
            int damage = 0;
            var name = string.Empty;
            var race = Race.Human;
            var raceIndex = string.Empty;

            switch (input)
            {
                case "1":
                    _consoleManager.Clear();

                    name = _consoleManager.GetDataFromUser("Enter your Nickname: ");

                    _consoleManager.Clear();

                    raceIndex = _consoleManager.GetDataFromUser("1. Human\n2. Dwarf\n\nChoose the RACE: ");

                    var paladin = new Paladin(name, health, level, stamina, strenghth, intellect, race, damage);

                    paladin.Health = 100 + paladin.Stamina;
                    paladin.Level = 1;
                    paladin.Stamina = 10;
                    paladin.Strenghth = 7;
                    paladin.Intellect = 3;
                    paladin.Damage = 10;

                    switch (raceIndex)
                    {
                        case "1":

                            paladin.Race = Race.Human;

                            break;

                        case "2":

                            paladin.Race = Race.Dwarf;

                            break;
                    }

                    _consoleManager.Clear();

                    Console.WriteLine($"Your Paladin Character is created" +
                        $"\n\nNickname - {paladin.Name}" +
                        $"\nHealth - {paladin.Health}" +
                        $"\nLevel - {paladin.Level}" +
                        $"\nRace - {paladin.Race}" +
                        $"\nBase Damage - {paladin.Damage}");
                    Console.ReadKey();

                    break;

                case "2":
                    _consoleManager.Clear();

                    name = _consoleManager.GetDataFromUser("Enter your Nickname: ");

                    _consoleManager.Clear();

                    raceIndex = _consoleManager.GetDataFromUser("1. Human\n2. Draenei\n\nChoose the RACE: ");

                    var mage = new Mage(name, health, level, stamina, strenghth, intellect, race, damage);

                    mage.Health = 100 + mage.Stamina;
                    mage.Level = 1;
                    mage.Stamina = 5;
                    mage.Strenghth = 3;
                    mage.Intellect = 7;
                    mage.Damage = 10;

                    switch (raceIndex)
                    {
                        case "1":

                            mage.Race = Race.Human;

                            break;

                        case "2":

                            mage.Race = Race.Draenei;

                            break;
                    }

                    _consoleManager.Clear();

                    Console.WriteLine($"Your Mage Character is created" +
                        $"\n\nNickname - {mage.Name}" +
                        $"\nHealth - {mage.Health}" +
                        $"\nLevel - {mage.Level}" +
                        $"\nRace - {mage.Race}" +
                        $"\nBase Damage - {mage.Damage}");
                    Console.ReadKey();

                    break;

                case "3":
                    _consoleManager.Clear();

                    name = _consoleManager.GetDataFromUser("Enter your Nickname: ");

                    _consoleManager.Clear();

                    raceIndex = _consoleManager.GetDataFromUser("1. Tauren\n2. Draenei\n\nChoose the RACE: ");

                    var shaman = new Shaman(name, health, level, stamina, strenghth, intellect, race, damage);

                    shaman.Health = 100 + shaman.Stamina;
                    shaman.Level = 1;
                    shaman.Stamina = 7;
                    shaman.Strenghth = 5;
                    shaman.Intellect = 5;
                    shaman.Damage = 10;

                    switch (raceIndex)
                    {
                        case "1":

                            shaman.Race = Race.Tauren;

                            break;

                        case "2":

                            shaman.Race = Race.Draenei;

                            break;
                    }

                    _consoleManager.Clear();

                    Console.WriteLine($"Your Shaman Character is created" +
                        $"\n\nNickname - {shaman.Name}" +
                        $"\nHealth - {shaman.Health}" +
                        $"\nLevel - {shaman.Level}" +
                        $"\nRace - {shaman.Race}" +
                        $"\nBase Damage - {shaman.Damage}");
                    Console.ReadKey();

                    break;
            }
        }
    }

}
