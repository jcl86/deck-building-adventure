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
                strength: initialValues.InitialStrength + randomGenerator.Number(0, 2),
                magic: initialValues.InitialMagic,
                health: CalculateHealth(),
                workPoints: initialValues.InitialWorkPoints,
                magicPoints: CalculateMagicPoints());
        }

        private int CalculateHealth()
        {
            return initialValues.InitialStrength * 2 + initialValues.InitialStrength;
        }

        private int CalculateMagicPoints()
        {
            return (int)Math.Round((decimal)(initialValues.InitialMagic / 2), 0);
        }
    }
}
