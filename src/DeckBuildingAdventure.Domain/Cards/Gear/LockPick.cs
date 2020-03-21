namespace DeckBuildingAdventure.Domain
{
    public class LockPick : GearCard
    {
        public override void Play(Character character, Enemy enemy)
        {
            character.WorkPoints.Increase(1);
            base.Play(character, enemy);
        }
    }
}
