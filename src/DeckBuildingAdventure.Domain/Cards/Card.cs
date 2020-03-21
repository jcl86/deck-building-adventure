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

        public override string ToString() => new NameFinderService().Find(GetType().Name);

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
}
