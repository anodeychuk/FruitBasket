using FruitBasket.Model;
using FruitBasket.Model.Core;
using FruitBasket.Players;
using FruitBasket.Referees;
using FruitBasket.View;
using System;

namespace FruitBasket
{
    /// <summary>
    /// The main program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The method serving as the entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guess Fruit Basket Game!");

            Referee referee = new Referee();
            PlayerFactory playerFactory = new PlayerFactory();

            CreatePlayers(referee, playerFactory);

            ViewService.StartGame();

            Console.WriteLine($"Fruit Basket Weight is {referee.FruitBasketWeight}");

            var winner = new GameCore().PerformGameProcess(referee);

            if(referee.Round < Config.MaxGameRound - 1)
            {
                ViewService.ShowWinner(winner); 
            }
            else
            {
                ViewService.ShowFuzzyWinner(winner);
            }

            ViewService.EndGame();
            CloseApplication();
        }

        /// <summary>
        /// Creates players.
        /// </summary>
        /// <param name="referee">The referee.</param>
        /// <param name="playerFactory">The player factory.</param>
        private static void CreatePlayers(Referee referee, PlayerFactory playerFactory)
        {
            int playersCount = ViewService.GetPlayersCount();
            if (playersCount == 0)
            {
                Close();
            }

            for (int i = 1; i <= playersCount; i++)
            {
                string name = ViewService.GetPlayerName(i);
                if (name.Length == 0)
                {
                    Close();
                }

                int playerType = ViewService.GetPlayerType(i);
                if (playerType == 0)
                {
                    Close();
                }

                referee.AddPlayer(
                    playerFactory.CreatePlayer(
                        name: name,
                        id: i,
                        playerType: (Config.PlayersTypes)(playerType - 1),
                        referee: referee));
            }

            referee.SetRandomPlayerOrder();
        }

        /// <summary>
        /// Informs the user about the application exit and closes the application.
        /// </summary>
        private static void Close()
        {
            ViewService.Sorry();
            CloseApplication();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private static void CloseApplication() => Environment.Exit(0);
    }
}