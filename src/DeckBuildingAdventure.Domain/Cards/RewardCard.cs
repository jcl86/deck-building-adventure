namespace DeckBuildingAdventure.Domain
{
    public abstract class RewardCard : ICard
    {
        public int Points { get; }
        public CardType Type => CardType.Reward;
        public abstract void Play(Character character, Enemy enemy);
    }
}
