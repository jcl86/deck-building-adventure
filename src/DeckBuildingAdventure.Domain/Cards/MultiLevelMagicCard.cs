namespace DeckBuildingAdventure.Domain
{
    public abstract class MultiLevelMagicCard : MagicCard
    {
        protected MagicLevel magicLevel;
        public abstract int BasePower { get; }
        public override int Power => magicLevel.AttackModifier(BasePower);

        public override int MinimunMagic => 4;

        public override bool CanBeUpgraded() => magicLevel.CanBeUpgraded;
        public void Upgrade() => magicLevel.Upgrade();

        public override string ToString() => $"{base.ToString()}{magicLevel.ToString()}";
    }
}
