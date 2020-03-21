namespace DeckBuildingAdventure.Domain
{
    public abstract class GearCard : Card
    {
        public override CardType Type => CardType.Equipment;
        public override bool CanBePlayed(Character character)
            => character.WorkPoints.HasPoints();

        public override void Play(Character character, Enemy enemy)
        {
            character.WorkPoints.Spend();
        }
    }
}
