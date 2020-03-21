using System;
using System.Collections.Generic;

namespace DeckBuildingAdventure.Domain
{
    public class Deck
    {
        private readonly IEnumerable<Card> cards;

        private IEnumerable<Card> pile;
        private IEnumerable<Card> discardPile;

        public Deck(params Card[] cards)
        {
            this.cards = cards;
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
