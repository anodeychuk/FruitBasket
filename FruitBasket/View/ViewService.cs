using FruitBasket.Model;
using System;

namespace FruitBasket.View
{
    /// <summary>
    /// The class implementing the view service.
    /// </summary>
    public static class ViewService
    {
        /// <summary>
        /// Gets the count of players to participate in the game.
        /// </summary>
        /// <returns>The count of players to participate in the game.</returns>
        public static int GetPlayersCount()
        {
            Console.WriteLine("How many players will be (from 2 to 8)?");
            int attempt = ViewConfig.NumberAttempts;
            int playersCount;

            while (!(int.TryParse(Console.ReadLine(), out playersCount) && (playersCount >= 2) && (playersCount <= 8))
                   && attempt > 0)
            {
                Console.WriteLine("You entered an invalid number. Please try again.");
                attempt--;
            }

            return playersCount;
        }

        /// <summary>
        /// Gets the player name.
        /// </summary>
        /// <param name="id">The player identifier.</param>
        /// <returns>The player name.</returns>
        public static string GetPlayerName(int id)
        {
            Console.WriteLine($"Please enter player name for {id} player:");
            int attempt = ViewConfig.NumberAttempts;
            string playerName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(playerName) && attempt > 0)
            {
                Console.WriteLine("You have entered an invalid name. Please try again.");
                attempt--;
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        /// <summary>
        /// Gets the player type.
        /// </summary>
        /// <param name="id">The player identifier.</param>
        /// <returns>The player type.</returns>
        public static int GetPlayerType(int id)
        {
            Console.WriteLine($"The player can be one of the following types:");

            foreach (var playerTypeNum in Enum.GetValues(typeof(Config.PlayersTypes)))
            {
                Console.WriteLine($"{(int)playerTypeNum + 1} - {playerTypeNum}");
            }
            Console.WriteLine($"Please enter the type for {id} player:");

            int attempt = ViewConfig.NumberAttempts;
            int playerType;

            while (
                !(int.TryParse(Console.ReadLine(), out playerType) && (playerType >= 1) && (playerType <= 5))
                && attempt > 0)
            {
                Console.WriteLine("You have entered an invalid number. Please try again.");
                attempt--;
            }

            return playerType;
        }

        /// <summary>
        /// Informs the user about an error occurred while entering data and the exit from the application.
        /// </summary>
        public static void Sorry()
        {
            Console.WriteLine("We are very sorry but an error occurred while entering data. The application will be closed.");
            Console.ReadKey();
        }

        /// <summary>
        /// Informs the user about the game start.
        /// </summary>
        public static void StartGame() => Console.WriteLine("The game started.");

        /// <summary>
        /// Informs the user about the game end.
        /// </summary>
        public static void EndGame()
        {
            Console.WriteLine("Game over. Thank you for being with us.");
            Console.ReadKey();
        }

        /// <summary>
        /// Informs the user about the winner when there wasn’t a clear winner.
        /// </summary>
        /// <param name="winner">The winner determined as the player whose guess was the closest to the real weight of the fruit basket.</param>
        public static void ShowFuzzyWinner((string playerName, int attempt, int weight) winner) =>
            Console.WriteLine($"The winner is {winner.playerName} who performed {winner.attempt} attempts and determined the weight of the basket as {winner.weight}.");

        /// <summary>
        /// Informs the user about the winner.
        /// </summary>
        /// <param name="winner">The winner.</param>
        public static void ShowWinner((string playerName, int attempt, int weight) winner) =>
            Console.WriteLine($"The winner is {winner.playerName} who performed {winner.attempt} attempts.");
    }
}