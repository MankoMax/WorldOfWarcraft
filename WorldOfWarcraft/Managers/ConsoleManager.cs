using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft.Managers
{
    public class ConsoleManager
    {
        public void Clear() => Console.Clear();

        public string ShowMenu()
        {
            Clear();

            Console.WriteLine("1 - Create new Character");
            Console.WriteLine("2 - Show all the Characters");
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
    }
}
