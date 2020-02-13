using FruitBasket.Players.Interfaces;
using System;
using System.Collections.Generic;

namespace FruitBasket.Referees.Interfaces
{
    /// <summary>
    /// The interface defining a referee.
    /// </summary>
    public interface IReferee
    {
        /// <summary>
        /// Gets the real weight of the fruit basket.
        /// </summary>
        int FruitBasketWeight { get; }

        /// <summary>
        /// Gets or sets the game rounds.
        /// </summary>
        int Round { get; set; }

        /// <summary>
        /// The event for subscription by players entered into cheating agreements with the referee.
        /// </summary>
        event Action<int> Cheating;

        /// <summary>
        /// Gets the list of numbers that were already been tried before by any of the players.
        /// </summary>
        List<KeyValuePair<int, int>> Numbers { get; }

        /// <summary>
        /// Adds the number already tried by any of the players.
        /// </summary>
        /// <param name="id">The player identifier.</param>
        /// <param name="number">The number already tried by the player.</param>
        void AddNumber(int id, int number);

        /// <summary>
        /// Gets the list of players participating in the game.
        /// </summary>
        List<IPlayer> Players { get; }

        /// <summary>
        /// Adds a new player to the game.
        /// </summary>
        /// <param name="player">The player to be added.</param>
        void AddPlayer(IPlayer player);

        /// <summary>
        /// Checks whether a guess about the weight of the fruit basket is correct.
        /// </summary>
        /// <param name="weight">The weight guessed.</param>
        /// <returns><c>true</c> if the guess about the weight of the fruit basket is correct; otherwise, <c>false</c></returns>
        bool IsBasketWeightCorrect(int weight);

        /// <summary>
        /// Gets the count of rounds to be skipped by a player.
        /// </summary>
        /// <param name="weightGuessed">The weight guessed.</param>
        /// <returns>The count of rounds to be skipped by a player.</returns>
        int GetSkipRoundCount(int weightGuessed);

        /// <summary>
        /// Sets the random order of player to participate in the game.
        /// </summary>
        void SetRandomPlayerOrder();

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <returns>The tuple consisting of the winner name,
        /// the number of attempts to guess the weight of the fruit basket,
        /// and the winner guess about the weight of the fruit basket.</returns>
        (string playerName, int attempt, int weight) GetWinner();
    }
}