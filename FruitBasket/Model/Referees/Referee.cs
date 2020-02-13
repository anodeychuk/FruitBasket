using FruitBasket.Model;
using FruitBasket.Players.Interfaces;
using FruitBasket.Referees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitBasket.Referees
{
    /// <summary>
    /// The class implementing a referee.
    /// </summary>
    public class Referee : IReferee
    {
        /// <summary>
        /// Gets the list of numbers that were already been tried before by any of the players.
        /// </summary>
        public List<KeyValuePair<int, int>> Numbers { get; }

        /// <summary>
        /// Gets the list of players participating in the game.
        /// </summary>
        public List<IPlayer> Players { get; }

        /// <summary>
        /// The event for subscription by players entered into cheating agreements with the referee.
        /// </summary>
        public event Action<int> Cheating;

        /// <summary>
        /// Gets the real weight of the fruit basket.
        /// </summary>
        public int FruitBasketWeight { get; }

        /// <summary>
        /// Gets or sets the game rounds.
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        public Referee()
        {
            Numbers = new List<KeyValuePair<int, int>>();
            Players = new List<IPlayer>();
            FruitBasketWeight = new Random().Next(Config.MinWeight, Config.MaxWeight); // RandomProvider.RndRound(Config.MinWeight, Config.MaxWeight);
        }

        /// <summary>
        /// Adds the number already tried by any of the players.
        /// </summary>
        /// <param name="id">The player identifier.</param>
        /// <param name="number">The number already tried by the player.</param>
        public void AddNumber(int id, int number)
        {
            Cheating?.Invoke(number);

            Numbers.Add(new KeyValuePair<int, int>(id, number));
        }

        /// <summary>
        /// Adds a new player to the game.
        /// </summary>
        /// <param name="player">The player to be added.</param>
        public void AddPlayer(IPlayer player) => Players.Add(player);

        /// <summary>
        /// Sets the random order of player to participate in the game.
        /// </summary>
        public void SetRandomPlayerOrder()
        {
            Random rnd = new Random();
            int n = Players.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);//RandomProvider.RndRound(0, n + 1);
                var value = Players[k];
                Players[k] = Players[n];
                Players[n] = value;
            }
        }

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <returns>The tuple consisting of the winner name,
        /// the number of attempts to guess the weight of the fruit basket,
        /// and the winner guess about the weight of the fruit basket.</returns>
        public (string playerName, int attempt, int weight) GetWinner()
        {
            var min = Numbers.Min(x => Math.Abs(x.Value - FruitBasketWeight));
            var winnerIdAndValue = Numbers.Where(x => (x.Value == FruitBasketWeight || Math.Abs(x.Value - FruitBasketWeight) == min))
                                            .Select(k => (k.Key, k.Value)).ToList()[0];

            var winner = Players.Where(x => x.Id == winnerIdAndValue.Key).Select(w => (w.Name, w.Attempt, winnerIdAndValue.Value)).ToList()[0];

            return winner;
        }

        /// <summary>
        /// Checks whether a guess about the weight of the fruit basket is correct.
        /// </summary>
        /// <param name="weight">The weight guessed.</param>
        /// <returns><c>true</c> if the guess about the weight of the fruit basket is correct; otherwise, <c>false</c></returns>
        public bool IsBasketWeightCorrect(int weight) => FruitBasketWeight == weight;

        /// <summary>
        /// Gets the count of rounds to be skipped by a player.
        /// </summary>
        /// <param name="weightGuessed">The weight guessed.</param>
        /// <returns>The count of rounds to be skipped by a player.</returns>
        public int GetSkipRoundCount(int guessedWeight) => Math.Abs(FruitBasketWeight - guessedWeight) / 10 - 1;
    }
}