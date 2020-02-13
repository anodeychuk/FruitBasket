using FruitBasket.Model;
using System;
using System.Collections.Generic;

namespace FruitBasket.Players
{
    /// <summary>
    /// The class implementing a player capable to guess a random number between 40 and 140
    /// but doesn’t try the same number more than once.
    /// </summary>
    public class MemoryPlayer : Player
    {
        /// <summary>
        /// Represents the pool of numbers to be used by a player during a game.
        /// </summary>
        protected List<int> NumberPool = new List<int>();

        /// <summary>
        /// Constructs a class instance.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="id">The player identifier.</param>
        public MemoryPlayer(string name, int id) : base(name, id)
        {
            for (int i = Config.MinWeight; i <= Config.MaxWeight; i++)
            {
                NumberPool.Add(i);
            }
        }

        /// <summary>
        /// Performs a memory players' action indented to guess the real weight of the basket.
        /// <remarks>The memory player doesn’t try the same number more than once.</remarks>
        /// </summary>
        /// <returns>The number between 40 and 140.</returns>
        public override int Action()
        {
            base.Action();

            int index = GetIndex();
            int result = NumberPool[index];
            NumberPool.RemoveAt(index);
            return result;
        }

        /// <summary>
        /// Gets the random index of a number from the number pool.
        /// </summary>
        /// <returns>The random index of a number from the number pool.</returns>
        public virtual int GetIndex() => new Random().Next(0, NumberPool.Count - 1);
    }
}