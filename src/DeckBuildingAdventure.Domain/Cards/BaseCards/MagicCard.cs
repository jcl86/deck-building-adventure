namespace DeckBuildingAdventure.Domain
{
    public abstract class MagicCard : Card, IMinimunMagicRequired
    {
        public override CardType Type => CardType.Magic;
        public abstract int Power { get; }
        public abstract int MinimunMagic { get; }
        public override bool CanBePlayed(Character character)
            => character.CanUse(this) && character.MagicPoints.HasPoints();

        public virtual bool CanBeUpgraded() => false;
    }
}
