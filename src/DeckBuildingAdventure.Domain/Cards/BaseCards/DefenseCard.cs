namespace DeckBuildingAdventure.Domain
{
    public abstract class DefenseCard : Card, IMinimunStrengthRequired
    {
        public override CardType Type => CardType.Equipment;
        public abstract int Defense { get; }
        public abstract int MinimunStrength { get; }
        public override bool CanBePlayed(Character character)
            => character.CanUse(this) && character.WorkPoints.HasPoints();

        public override void Play(Character character, Enemy enemy)
        {
            character.Defense.AddDefense(Defense);
            character.WorkPoints.Spend();
        }
    }
}
