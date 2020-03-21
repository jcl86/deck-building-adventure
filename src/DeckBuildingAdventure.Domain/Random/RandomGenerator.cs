using System;

namespace DeckBuildingAdventure.Domain
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random random;

        public RandomGenerator(Random random)
        {
            this.random = random;
        }

        public int Number(int minimun, int maximun)
        {
            return random.Next(minimun, maximun + 1);
        }
    }
}
