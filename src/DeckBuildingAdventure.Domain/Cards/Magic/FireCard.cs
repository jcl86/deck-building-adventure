namespace DeckBuildingAdventure.Domain
{
    public class FireCard : MultiLevelMagicCard, INatureElemental
    {
        public override int BasePower => 3;
        public override int MinimunMagic => 4;
        public NatureElement Element => NatureElement.Fire;

        public override void Play(Character character, Enemy enemy)
        {
            enemy.SufferMagicalDamage(Power);
            character.MagicPoints.Spend();
        }
    }
}
