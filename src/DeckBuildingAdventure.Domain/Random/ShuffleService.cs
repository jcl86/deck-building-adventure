using System.Collections.Generic;

namespace DeckBuildingAdventure.Domain
{
    public class ShuffleService<T>
    {
        private readonly IRandomGenerator randomGenerator;

        public ShuffleService(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public IEnumerable<T> Shuffle(List<T> origin)
        {
            List<T> mazoAuxiliar = new List<T>();

            int length = origin.Count;
            for (int i = 0; i < length; i++)
            {
                int pos = randomGenerator.GetNumber(0, origin.Count - 1);
                T o = origin[pos];
                mazoAuxiliar.Add(o);
                origin.Remove(o);
            }
            return mazoAuxiliar;
        }
    }
}
