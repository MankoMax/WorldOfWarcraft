using WorldOfWarcraft.Managers;

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
