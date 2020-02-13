namespace FruitBasket.Model
{
    /// <summary>
    /// The class implementing the application configuration.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Represents the minimum weight of the fruit basket.
        /// </summary>
        public const int MinWeight = 40;

        /// <summary>
        /// Represents the maximum weight of the fruit basket.
        /// </summary>
        public const int MaxWeight = 140;

        /// <summary>
        /// Represents the maximum number of game rounds.
        /// </summary>
        public const int MaxGameRound = 100;

        /// <summary>
        /// The enumeration defining the player types.
        /// </summary>
        public enum PlayersTypes
        {
            Random,
            Memory,
            Thorough,
            Cheater,
            ThoroughCheater
        }
    }
}