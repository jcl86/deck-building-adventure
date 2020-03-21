namespace DeckBuildingAdventure.Domain
{
    public class AlwaysMinimunNumber : IRandomGenerator
    {
        public int GetNumber(int minimun, int maximun) => minimun;
    }
}
