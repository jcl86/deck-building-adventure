namespace DeckBuildingAdventure.Domain
{
    public struct JobInitialValues
    {
        private readonly int initialStrength;
        public int InitialStrength => initialStrength;

        public int InitialMagic { get; }
        public int InitialWorkPoints { get; }

        public JobInitialValues(int initialStrength, int initialMagic, int initialWorkPoints)
        {
            initialStrength = initialStrength;
            InitialMagic = initialMagic;
            InitialWorkPoints = initialWorkPoints;
        }
    }
}
