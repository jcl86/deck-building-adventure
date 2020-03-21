namespace DeckBuildingAdventure.Domain
{
    public abstract class RewardCard : Card
    {
        public int Points { get; }
        public override CardType Type => CardType.Reward;

        public RewardCard(int points)
        {
            Points = points;
        }

        public override void Play(Character character, Enemy enemy) { }

        public override string ToString() => $"{Points}{(Points != 1 ? "s" : "")} reward";
    }
}
