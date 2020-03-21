using System;

namespace DeckBuildingAdventure.Domain
{
    public abstract class Card
    {
        private Guid id;

        protected Card()
        {
            id = Guid.NewGuid();
        }

        public abstract CardType Type { get; }
        public virtual bool CanBePlayed(Character character) => false;
        public abstract void Play(Character character, Enemy enemy);

        public static bool operator ==(Card obj1, Card obj2) => obj1.Equals(obj2);
        public static bool operator !=(Card obj1, Card obj2) => !obj1.Equals(obj2);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Card)obj;
            return other.id.Equals(id);
        }

        public override int GetHashCode() => id.GetHashCode();
    }

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

    public abstract class MagicCard : Card, IMinimunMagicRequired
    {
        public override CardType Type => CardType.Magic;
        public abstract int Attack { get; }
        public abstract int MinimunMagic { get; }
        public override bool CanBePlayed(Character character)
            => character.CanUse(this) && character.MagicPoints.HasPoints();

        public override void Play(Character character, Enemy enemy)
        {
            enemy.SufferMagicalDamage(Attack);
            character.MagicPoints.Spend();
        }
    }

    public class NameFinder
    {
        private string className;

        public NameFinder(string className)
        {
            this.className = className;
        }
    }

    public abstract class MultiLevelMagicCard : MagicCard
    {
        protected int magicLevel;
        public abstract int BaseAttack { get;  }
        public override int Attack => (int)Math.Pow(3, magicLevel);

        public override int MinimunMagic => 4;

        public bool CanBeUpgraded() => magicLevel < 3;
        public void Upgrade()
        {
            if (!CanBeUpgraded())
            {
                throw new DomainException($"{GetType().Name} can not be upgraded");
            }
            magicLevel++;
        }
        public override string ToString() => "";
    }

    public abstract class ClothCard : Card
    {
        public override CardType Type => CardType.Equipment;
        public override bool CanBePlayed(Character character)
            => character.WorkPoints.HasPoints();

        public override void Play(Character character, Enemy enemy)
        {
            character.WorkPoints.Spend();
        }
    }

    public interface IMinimunStrengthRequired
    {
        int MinimunStrength { get; }
    }

    public interface IMinimunMagicRequired
    {
        int MinimunMagic { get; }
    }

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

    public class Dagger : WeaponCard
    {
        public override int Attack => 3;
        public override int MinimunStrength => 2;
    }

    public class LockPick : ClothCard
    {
        public override void Play(Character character, Enemy enemy)
        {
            character.WorkPoints.Increase(1);
            base.Play(character, enemy);
        }
    }

    public class WoodenShield : DefenseCard
    {
        public override int Defense => 1;
        public override int MinimunStrength => 2;
    }

    public class Rod : WeaponCard
    {
        public override int Attack => 1;
        public override int MinimunStrength => 1;
    }

    public class Sword : WeaponCard
    {
        public override int Attack => 5;
        public override int MinimunStrength => 3;
    }

    public class IronArmour : DefenseCard
    {
        public override int Defense => 2;
        public override int MinimunStrength => 4;
    }


    public class Fire : MagicCard
    {
        private int magicLevel = 1;
        public override int Attack => (int)Math.Pow(3, magicLevel);

        public override int MinimunMagic => 4;

        public bool CanBeUpgraded() => magicLevel < 3;
        public void Upgrade()
        {
            if (!CanBeUpgraded())
            {
                throw new DomainException($"{GetType().Name} can not be upgraded");
            }
            magicLevel++;
        }
        public override string ToString() => "";
    }
}
