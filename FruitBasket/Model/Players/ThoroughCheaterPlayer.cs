using FruitBasket.Model.Players.Interfaces;

namespace FruitBasket.Players
{
    /// <summary>
    /// The class implementing a player capable to try all numbers by order – 41, 42, 43, but
    /// skips numbers that were already been tried before by any of the players.
    /// </summary>
    public class ThoroughCheaterPlayer : ThoroughPlayer, ICheaterPlayer
    {
        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        public ThoroughCheaterPlayer(string name, int id) : base(name, id)
        {
        }

        /// <summary>
        /// Performs a cheating action.
        /// </summary>
        /// <param name="number">The number between 40 and 140 entered by another player.</param>
        public void CheatingAction(int number) => NumberPool.RemoveAll(x => x == number);
    }
}