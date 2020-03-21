using System.Collections.Generic;
using System.Linq;

namespace DeckBuildingAdventure.Domain
{
    public class Battle
    {
        private readonly IEnumerable<Enemy> enemies;
        public int Objetive { get; }
        public int CurrentPoints => enemies
            .Where(x => x.IsDeath)
            .Sum(x => x.RewardCard.Points);
        public bool IsEnded() => CurrentPoints >= Objetive;

        public Battle(int objetive, params Enemy[] enemies)
        {
            Objetive = objetive;
            this.enemies = enemies;
        }
    }
}
