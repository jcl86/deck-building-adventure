namespace DeckBuildingAdventure.Domain
{
    public abstract class WeaponCard : Card, IMinimunStrengthRequired
    {
        public override CardType Type => CardType.Equipment;
        public abstract int Attack { get; }
        public abstract int MinimunStrength { get; }
        public override bool CanBePlayed(Character character)
            => character.CanUse(this) && character.WorkPoints.HasPoints();

        public override void Play(Character character, Enemy enemy)
        {
            enemy.SufferPhisicalDamage(Attack);
            character.WorkPoints.Spend();
        }
    }
}
