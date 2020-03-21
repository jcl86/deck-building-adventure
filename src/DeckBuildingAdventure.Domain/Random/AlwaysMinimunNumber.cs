namespace DeckBuildingAdventure.Domain
{
    public class AlwaysMinimunNumber : IRandomGenerator
    {
        public int Number(int minimun, int maximun) => minimun;
    }
}
