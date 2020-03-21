using System;

namespace DeckBuildingAdventure.Domain
{
    public class ExpendablePoint
    {
        public int MaxValue { get; }
        public int CurrentValue { get; private set; }

        public ExpendablePoint(int maxValue)
        {
            MaxValue = maxValue;
            CurrentValue = maxValue;
        }

        public bool HasPoints() => CurrentValue > 0;
        public void Spend()
        {
            if (!HasPoints())
            {
                throw new DomainException("Can not spend more points");
            }
            CurrentValue--;
        }
        public void NewTurn() => CurrentValue = MaxValue;
        public void Increase(int quantity)
            => CurrentValue = Math.Min(MaxValue, CurrentValue + quantity);
    }
}
