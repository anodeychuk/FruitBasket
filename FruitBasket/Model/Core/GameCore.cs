using FruitBasket.Model.Core.Interfaces;
using FruitBasket.Referees;

namespace FruitBasket.Model.Core
{
    /// <summary>
    /// The class implementing the core logic of the game process.
    /// </summary>
    public class GameCore : IGameCore
    {
        /// <summary>
        /// Performs the game process.
        /// </summary>
        /// <param name="referee">The referee of the game.</param>
        /// <returns>The tuple consisting of the winner name,
        /// the number of attempts to guess the weight of the fruit basket,
        /// and the winner guess about the weight of the fruit basket.</returns>
        public (string playerName, int attempt, int weight) PerformGameProcess(Referee referee)
        {
            bool IsBasketWeightFound = false;
            for (int i = 0; i < Config.MaxGameRound; i++)
            {
                referee.Round = i;
                foreach (var player in referee.Players)
                {
                    if (player.SkipRoundCount == 0)
                    {
                        int number = player.Action();
                        referee.AddNumber(player.Id, number);
                        player.Attempt++;
                        if (referee.IsBasketWeightCorrect(number))
                        {
                            IsBasketWeightFound = true;
                            break;
                        }
                        else
                        {
                            player.SkipRoundCount = referee.GetSkipRoundCount(number);
                        }
                    }
                    else
                    {
                        player.SkipRoundCount--;
                    }
                }
                if (IsBasketWeightFound)
                {
                    break;
                }
            }

            return referee.GetWinner();
        }
    }
}