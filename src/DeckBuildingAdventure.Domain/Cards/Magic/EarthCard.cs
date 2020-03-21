namespace DeckBuildingAdventure.Domain
{
    public class EarthCard : MultiLevelMagicCard, INatureElemental
    {
        public override int BasePower => 5;
        public override int MinimunMagic => 5;
        public NatureElement Element => NatureElement.Earth;

        public override void Play(Character character, Enemy enemy)
        {
            enemy.SufferMagicalDamage(Power);
            character.MagicPoints.Spend();
        }
    }
}
