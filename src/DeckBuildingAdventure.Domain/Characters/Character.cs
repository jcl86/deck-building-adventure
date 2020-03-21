using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckBuildingAdventure.Domain
{
    public class Deck
    {
        private readonly IEnumerable<Card> cards;

        private IEnumerable<Card> pile;
        private List<Card> discardPile;

        public Deck(DeckFactory deckFactory, ShuffleService<Card> shuffleService)
        {
            cards =  shuffleService.Shuffle(deckFactory.Create().ToList());
            pile = shuffleService.Shuffle(deckFactory.Create().ToList());
        }

        public bool CanBeTaken(int number) => pile.Count() >= number;
        public IEnumerable<Card> DrawCards(int number)
        {
            if (!CanBeTaken(number))
            {
                throw new DomainException($"Can not take {number} cards beacause there are only {pile.Count()} cards");
            }
            var taken = pile.Take(number);
            return taken;
        }
        public void Discard(Card card)
        {
            discardPile.Add(card);
        }
        public void Restart()
        {
            pile = discardPile.ToList();
        }
    }

    public abstract class DeckFactory
    {
        protected IRandomGenerator randomGenerator;

        public DeckFactory(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public abstract IEnumerable<Card> Create();
    }

    public class ThiefDeckFactory : DeckFactory
    {
        public ThiefDeckFactory(IRandomGenerator randomGenerator) : base(randomGenerator) { }

        public override IEnumerable<Card> Create()
        {
            yield return new Dagger();
            yield return new Dagger();
            yield return new Dagger();
            yield return new Dagger();
            yield return new LockPick();
            yield return new LockPick();
            yield return new WoodenShield();
            yield return new WoodenShield();
        }
    }

    public class WarriorDeckFactory : DeckFactory
    {
        public WarriorDeckFactory(IRandomGenerator randomGenerator) : base(randomGenerator) { }

        public override IEnumerable<Card> Create()
        {
            yield return new Sword();
            yield return new Sword();
            yield return new Sword();
            yield return new IronArmour();
            yield return new IronArmour();
            yield return new IronArmour();
            yield return new WoodenShield();
            yield return new WoodenShield();
        }
    }

    public class WizardDeckFactory : DeckFactory
    {
        private readonly NatureElement element;

        public WizardDeckFactory(IRandomGenerator randomGenerator) : base(randomGenerator)
        {
            element = randomGenerator.GetElement();
        }

        public override IEnumerable<Card> Create()
        {
            yield return GetElementalCard();
            yield return GetElementalCard();
            yield return GetElementalCard();
            yield return GetElementalCard();
            yield return new Rod();
            yield return new Rod();
            yield return new Spirit();
            yield return new Spirit();
        }

        private Card GetElementalCard()
        {
            switch (element)
            {
                case NatureElement.Fire: return new FireCard();
                case NatureElement.Water: return new WaterCard();
                case NatureElement.Earth: return new EarthCard();
                case NatureElement.Wind: return new WindCard();
            }
            throw new NotImplementedException();
        }
    }

    public class Character
    {
        private readonly int level;
        private readonly Job job;

        public Character(Job job, int strength, int magic, int health, int workPoints, int magicPoints)
        {
            level = 1;
            this.job = job;
            Strength = strength;
            Magic = magic;
            Health = health;
            WorkPoints = new ExpendablePoint(workPoints);
            MagicPoints = new ExpendablePoint(magicPoints);
        }

        public int Strength { get; private set; }
        public bool CanUse(IMinimunStrengthRequired card)
            => Strength >= card.MinimunStrength;
        public bool CanUse(IMinimunMagicRequired card)
            => Magic >= card.MinimunMagic;
        public int Magic { get; private set; }

        public int Health { get; private set; }

        public Defense Defense { get; private set; }

        public ExpendablePoint WorkPoints { get; private set; }
        public ExpendablePoint MagicPoints { get; private set; }

        public override string ToString() => $"{job.ToString()} (Lvl {level})";
    }

    public class Defense
    {
        public int MaxDefense { get; }
        public int CurrentValue { get; private set; }

        public Defense(int maxDefense)
        {
            CurrentValue = 0;
            MaxDefense = maxDefense;
        }

        public void AddDefense(int value)
        {
            CurrentValue = Math.Min(CurrentValue + value, MaxDefense);
        }

        public void NewTurn() => CurrentValue = 0;
    }
}
