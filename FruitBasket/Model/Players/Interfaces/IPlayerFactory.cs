using FruitBasket.Players.Interfaces;
using FruitBasket.Referees.Interfaces;

namespace FruitBasket.Model.Players.Interfaces
{
    /// <summary>
    /// The interface defining the factory to create players.
    /// </summary>
    public interface IPlayerFactory
    {
        /// <summary>
        /// Creates a player of requested type.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        /// <param name="playerType">The requested type of a player to be created.</param>
        /// <param name="referee">The referee of the game.</param>
        /// <returns>The player of requested type.</returns>
        IPlayer CreatePlayer(string name, int id, Config.PlayersTypes playerType, IReferee referee);
    }
}