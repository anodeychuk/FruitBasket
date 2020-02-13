using FruitBasket.Referees;

namespace FruitBasket.Model.Core.Interfaces
{
    /// <summary>
    /// The interface defining the core logic of the game process.
    /// </summary>
    public interface IGameCore
    {
        /// <summary>
        /// Performs the game process.
        /// </summary>
        /// <param name="referee">The referee of the game.</param>
        /// <returns>The tuple consisting of the winner name,
        /// the number of attempts to guess the weight of the fruit basket,
        /// and the winner guess about the weight of the fruit basket.</returns>
        (string playerName, int attempt, int weight) PerformGameProcess(Referee referee);
    }
}