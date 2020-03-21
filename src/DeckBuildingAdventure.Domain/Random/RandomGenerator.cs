using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckBuildingAdventure.Domain
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random random;

        public RandomGenerator(Random random)
        {
            this.random = random;
        }

        public NatureElement GetElement() => (NatureElement)GetNumber(0, 3);

        public int GetNumber(int minimun, int maximun)
        {
            return random.Next(minimun, maximun + 1);
        }

        public T GetRandomItem<T>(IEnumerable<T> lista)
        {
            if (lista == null || !lista.Any())
                return default;

            return lista.ElementAt(GetNumber(0, lista.Count() - 1));
        }
    }
}
