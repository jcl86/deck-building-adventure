using System;
using System.Linq;

namespace DeckBuildingAdventure.Domain
{
    public class MagicLevel
    {
        private const int MaxLevel = 3;

        private int level;
        public bool Completed => MaxLevel == 3;
        public bool CanBeUpgraded => !Completed;

        public void Upgrade()
        {
            if (!CanBeUpgraded)
            {
                throw new DomainException($"{ToString()} can not be upgraded");
            }
            level++;
        }

        public MagicLevel()
        {
            level = 1;
        }

        public int AttackModifier(int baseAttack)
        {
            return (int)Math.Pow(3, baseAttack);
        }

        public override string ToString() => string.Join("", Enumerable.Range(1, level).Select(X => "+"));
    }
}
