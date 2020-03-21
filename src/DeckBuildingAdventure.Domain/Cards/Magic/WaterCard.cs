namespace DeckBuildingAdventure.Domain
{
    public class WaterCard : MultiLevelMagicCard, INatureElemental
    {
        public override int BasePower => 4;
        public override int MinimunMagic => 4;
        public NatureElement Element => NatureElement.Water;

        public override void Play(Character character, Enemy enemy)
        {
            enemy.SufferMagicalDamage(Power);
            character.MagicPoints.Spend();
        }
    }
}
