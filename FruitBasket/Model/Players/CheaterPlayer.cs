using FruitBasket.Model.Players.Interfaces;

namespace FruitBasket.Players
{
    /// <summary>
    /// The class implementing a player capable to guess a random number
    /// between 40 and 140 – but doesn’t try any of the numbers that other players had already tried.
    /// </summary>
    public class CheaterPlayer : MemoryPlayer, ICheaterPlayer
    {
        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        public CheaterPlayer(string name, int id) : base(name, id)
        {
        }

        /// <summary>
        /// Performs a cheating action.
        /// </summary>
        /// <param name="number">The number between 40 and 140 entered by another player.</param>
        public void CheatingAction(int number) => NumberPool.RemoveAll(x => x == number);
    }
}