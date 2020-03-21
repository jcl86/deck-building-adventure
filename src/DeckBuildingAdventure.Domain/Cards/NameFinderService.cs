namespace DeckBuildingAdventure.Domain
{
    public class NameFinderService
    {
        public NameFinderService()
        {

        }

        public string Find(string cardclassName)
        {
            return cardclassName;
        }

        public string Find<T>() where T : Card => Find(typeof(T).Name);
    }
}
