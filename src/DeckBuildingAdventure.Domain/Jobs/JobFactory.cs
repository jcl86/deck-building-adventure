namespace DeckBuildingAdventure.Domain
{
    public static class JobFactory
    {
        public static Job Thief => new Job("Thief", ThiefInitialValues);
        public static Job Warrior => new Job("Warrior", WarriorInitialValues);
        public static Job Wizard => new Job("Wizard", WizardInitialValues);

        private static JobInitialValues ThiefInitialValues => new JobInitialValues(
            initialStrength: 4,
            initialMagic: 0, 
            initialWorkPoints: 4);

        private static JobInitialValues WarriorInitialValues => new JobInitialValues(
             initialStrength: 8,
             initialMagic: 0,
             initialWorkPoints: 3);

        private static JobInitialValues WizardInitialValues => new JobInitialValues(
            initialStrength: 2,
            initialMagic: 6,
            initialWorkPoints: 1);

    }
}
