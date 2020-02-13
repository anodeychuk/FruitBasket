using FruitBasket.Model;
using FruitBasket.Model.Core;
using FruitBasket.Players;
using FruitBasket.Referees;
using System;
using Xunit;

namespace TestFruitBasket
{
    /// <summary>
    /// The class intended for testing the core logic of the game.
    /// </summary>
    public class GameCoreTest
    {
        /// <summary>
        /// Checks whether the game process is correct.
        /// </summary>
        [Fact]
        public void GameProcessTest()
        {
            var referee = new RefereeTest().GetReferee();

            referee.SetRandomPlayerOrder();

            var winner = new GameCore().PerformGameProcess(referee);

            // alternative approach (not Linq) to determining the winner
            int minNumber = Config.MaxWeight + 1;
            int minWeight = Config.MaxWeight + 1;
            int minId = -1;
            foreach (var number in referee.Numbers)
            {
                var value = Math.Abs(number.Value - referee.FruitBasketWeight);
                if (value < minNumber)
                {
                    minNumber = value;
                    minWeight = number.Value;
                    minId = number.Key;
                }
            }

            string playerName = string.Empty;
            foreach (var player in referee.Players)
            {
                if(player.Id == minId)
                {
                    playerName = player.Name;
                }
            }

            Assert.True(winner.playerName.Equals(playerName), "The name of the winner is not correctly determined");
            Assert.True(winner.weight == minWeight, "Weight not correctly determined");
        }


    }
}