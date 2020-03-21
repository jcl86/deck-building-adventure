using System;

namespace DeckBuildingAdventure.Domain
{
    public class Enemy
    {
        private readonly string name;

        public int Health { get; private set; }

        public int Strength { get; }
        public Defense Defense { get; }

        public bool IsDeath => Health <= 0;
        public RewardCard RewardCard { get; }

        public Enemy(string name, int health, int strength, int defense, RewardCard reward)
        {
            this.name = name;
            Health = health;
            Strength = strength;
            Defense = new Defense(defense);
            RewardCard = reward;
        }

        public void SufferPhisicalDamage(int damage)
        {
            int currentDamage = Math.Max(0, damage - Defense.CurrentValue);
            Health -= currentDamage;
        }

        public void SufferMagicalDamage(int damage)
        {
            Health -= damage;
        }

        public override string ToString() => name;
    }
}
