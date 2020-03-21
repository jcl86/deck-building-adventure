using System.Collections.Generic;

namespace DeckBuildingAdventure.Domain
{
    public interface IRandomGenerator
    {
        int GetNumber(int minimun, int maximun);
        NatureElement GetElement();
        T GetRandomItem<T>(IEnumerable<T> lista);
    }
}
