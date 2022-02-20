using Newtonsoft.Json;
using System;
using System.IO;
using WorldOfWarcraft.Managers;
using WorldOfWarcraft.Models;

namespace WorldOfWarcraft
{
    class Program
    {
        public static void Main()
        {
            var gameManager = new GameManager();

            gameManager.StartGame();
        }
    }
}
