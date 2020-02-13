using FruitBasket.Model;
using FruitBasket.Players.Interfaces;

namespace FruitBasket.Players
{
    /// <summary>
    /// The abstract class implementing the basic logic of a player.
    /// </summary>
    public abstract class Player : IPlayer
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the total amount of attempts available to a player
        /// to guess the real weight of the basket.
        /// </summary>
        public int Attempt { get; set; }

        /// <summary>
        /// Gets or sets the count of rounds to be skipped by a player.
        /// </summary>
        public int SkipRoundCount { get; set; }

        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        public Player(string name, int id)
        {
            Name = name;
            Id = id;
            Attempt = 0;
        }

        /// <summary>
        /// Performs a players' action indented to guess the real weight of the basket.
        /// </summary>
        /// <returns>The number between 40 and 140.</returns>
        public virtual int Action()
        {
            Attempt++;
            return Config.MinWeight;
        }
    }
}