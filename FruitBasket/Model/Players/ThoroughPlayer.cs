namespace FruitBasket.Players
{
    /// <summary>
    /// The class implementing a player capable to try all numbers by order – 41, 42, 43 etc.
    /// </summary>
    public class ThoroughPlayer : MemoryPlayer
    {
        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        public ThoroughPlayer(string name, int id) : base(name, id)
        {
        }

        /// <summary>
        /// Gets the index of a number from the number pool.
        /// </summary>
        /// <returns>The index of a number from the number pool.</returns>
        public override int GetIndex() => 0;
    }
}