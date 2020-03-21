namespace DeckBuildingAdventure.Domain
{
    public class Spirit : MagicCard
    {
        public override int Power => 2;
        public override int MinimunMagic => 4;

        public override void Play(Character character, Enemy enemy)
        {
            character.MagicPoints.Spend();
            character.MagicPoints.Increase(2);
        }
    }
}
