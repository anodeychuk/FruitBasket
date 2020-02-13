using FruitBasket.Model;
using FruitBasket.Model.Players.Interfaces;
using FruitBasket.Players.Interfaces;
using FruitBasket.Referees.Interfaces;

namespace FruitBasket.Players
{
    /// <summary>
    /// The class implementing the factory to create players.
    /// </summary>
    public class PlayerFactory : IPlayerFactory
    {
        /// <summary>
        /// Creates a player of requested type.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        /// <param name="playerType">The requested type of a player to be created.</param>
        /// <param name="referee">The referee of the game.</param>
        /// <returns>The player of requested type.</returns>
        public IPlayer CreatePlayer(string name, int id, Config.PlayersTypes playerType, IReferee referee)
        {
            IPlayer player;

            switch (playerType)
            {
                case Config.PlayersTypes.Random:
                    player = new RandomPlayer(name, id);
                    break;

                case Config.PlayersTypes.Memory:
                    player = new MemoryPlayer(name, id);
                    break;

                case Config.PlayersTypes.Thorough:
                    player = new ThoroughPlayer(name, id);
                    break;

                case Config.PlayersTypes.Cheater:
                    player = new CheaterPlayer(name, id);
                    CheatingAgreement(player, referee);
                    break;

                case Config.PlayersTypes.ThoroughCheater:
                    player = new ThoroughCheaterPlayer(name, id);
                    CheatingAgreement(player, referee);
                    break;

                default:
                    player = new RandomPlayer(name, id);
                    break;
            }

            return player;
        }

        /// <summary>
        /// Enters into a cheating agreement between a player and a referee.
        /// <remarks>The referee informs the player about guesses made by the other players.</remarks>
        /// </summary>
        /// <param name="player">The player entering into a cheating agreement.</param>
        /// <param name="referee">The referee entering into a cheating agreement.</param>
        private void CheatingAgreement(IPlayer player, IReferee referee)
        {
            if (player is ICheaterPlayer)
            {
                referee.Cheating += ((ICheaterPlayer)player).CheatingAction;
            }
        }
    }
}