namespace FruitBasket.Model.Players.Interfaces
{
    /// <summary>
    /// The interface defining a player capable to cheat.
    /// </summary>
    public interface ICheaterPlayer
    {
        /// <summary>
        /// Performs a cheating action.
        /// </summary>
        /// <param name="number">The number between 40 and 140 entered by another player.</param>
        void CheatingAction(int number);
    }
}