namespace FruitBasket.Players.Interfaces
{
    /// <summary>
    /// The interface defining a player.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the total amount of attempts available to a player
        /// to guess the real weight of the basket.
        /// </summary>
        int Attempt { get; set; }

        /// <summary>
        /// Gets or sets the count of rounds to be skipped by a player.
        /// </summary>
        int SkipRoundCount { get; set; }

        /// <summary>
        /// Performs a players' action indended to guess the real weight of the basket.
        /// </summary>
        /// <returns>The number between 40 and 140.</returns>
        int Action();
    }
}