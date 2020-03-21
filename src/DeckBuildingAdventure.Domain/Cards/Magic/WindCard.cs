namespace DeckBuildingAdventure.Domain
{
    public class WindCard : MultiLevelMagicCard, INatureElemental
    {
        public override int BasePower => 6;
        public override int MinimunMagic => 5;
        public NatureElement Element => NatureElement.Wind;

        public override void Play(Character character, Enemy enemy)
        {
            enemy.SufferMagicalDamage(Power);
            character.MagicPoints.Spend();
        }
    }
}
