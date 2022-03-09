using System;
using System.Collections.Generic;
using System.Linq;
using WorldOfWarcraft.Models;

namespace WorldOfWarcraft.Managers
{
    public class ConsoleManager
    {
        public void Clear() => Console.Clear();

        public string ShowMenu()
        {
            Clear();
            Console.WriteLine("|YOUR ACCOUNT|\n");
            Console.WriteLine("1 - Create new Character");
            Console.WriteLine("2 - Choose a Character");
            Console.WriteLine("\n3 - Exit the Game");

            return GetDataFromUser("\nType the command and press Enter : > ");
        }

        public string ShowGameMenu()
        {
            Clear();
            Console.WriteLine("|WELCOME TO WORLD of WARCRAFT GAME|\n");
            Console.WriteLine("1 - Create new Account");
            Console.WriteLine("2 - Log-in");
            Console.WriteLine("\n3 - Exit the Game");

            return GetDataFromUser("\nType the command and press Enter : > ");
        }

        public string GetDataFromUser(string messageToShow, bool shouldAddNewLine = false)
        {
            if (shouldAddNewLine)
            {
                Console.WriteLine(messageToShow);
            }
            else
            {
                Console.Write(messageToShow);
            }

            var userResult = Console.ReadLine();

            return userResult;
        }

        public void PrintMessage(string message)
        {
            Clear();

            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void DisplayCharacterList(List<Character> characterList)
        {
            Console.WriteLine("| YOUR ACCOUNT |");

            foreach (var chosenCharacter in characterList)
            {
                Console.Write($"\n{characterList.IndexOf(chosenCharacter) + 1})" +
                    $"{chosenCharacter.Name}\n{chosenCharacter.CharacterType}\n" +
                    $"{chosenCharacter.Race}\n");
            }
        }

        public void DisplayRaces(List<Race> races)
        {
            var types = races
                .Select(item => item.ToString())
                .ToList();

            DisplayOrderedList(types);
        }

        public void DisplayClasses()
        {
            var types = Enum
                .GetValues(typeof(CharacterType))
                .Cast<CharacterType>()
                .Select(item => item.ToString())
                .ToList();

            DisplayOrderedList(types);
        }

        private void DisplayOrderedList(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{items[i]}");
            }
        }
    }
}