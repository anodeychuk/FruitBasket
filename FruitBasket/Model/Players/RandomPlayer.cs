using FruitBasket.Model;
using System;

namespace FruitBasket.Players
{
    /// <summary>
    /// The class implementing a player capable to guess a random number between 40 and 140
    /// but doesn’t try the same number more than once.
    /// </summary>
    public class RandomPlayer : Player
    {
        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        public RandomPlayer(string name, int id) : base(name, id)
        {
        }

        /// <summary>
        /// Performs a players' action indented to guess the real weight of the basket.
        /// </summary>
        /// <returns>The number between 40 and 140.</returns>
        public override int Action()
        {
            base.Action();
            return new Random().Next(Config.MinWeight, Config.MaxWeight);
        }
    }
}