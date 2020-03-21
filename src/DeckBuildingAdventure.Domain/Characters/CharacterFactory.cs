using System;

namespace DeckBuildingAdventure.Domain
{
    public class CharacterFactory
    {
        private readonly Job job;
        private readonly IRandomGenerator randomGenerator;
        private readonly JobInitialValues initialValues;

        public CharacterFactory(Job job, IRandomGenerator randomGenerator)
        {
            this.job = job;
            this.randomGenerator = randomGenerator;
            initialValues = job.InitialValues;
        }

        public Character Create()
        {
            return new Character(job,
                strength: initialValues.InitialStrength + randomGenerator.GetNumber(0, 2),
                magic: Math.Max(0, initialValues.InitialMagic + randomGenerator.GetNumber(-2, 2)),
                health: CalculateHealth(),
                workPoints: initialValues.InitialWorkPoints,
                magicPoints: CalculateMagicPoints());
        }

        private int CalculateHealth()
        {
            return Math.Min(5, initialValues.InitialStrength * 2 + initialValues.InitialStrength) + randomGenerator.GetNumber(-2, 2);
        }

        private int CalculateMagicPoints()
        {
            return (int)Math.Round((decimal)(initialValues.InitialMagic / 2), 0);
        }
    }
}
