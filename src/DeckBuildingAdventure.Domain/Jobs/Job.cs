namespace DeckBuildingAdventure.Domain
{

    public class Job
    {
        private readonly string name;
        public JobInitialValues InitialValues { get; }

        public Job(string name, JobInitialValues initialValues)
        {
            this.name = name;
            InitialValues = initialValues;
        }

        public override string ToString() => name;

        public static bool operator ==(Job obj1, Job obj2) => obj1.Equals(obj2);
        public static bool operator !=(Job obj1, Job obj2) => !obj1.Equals(obj2);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Job)obj;
            return other.name.Equals(name);
        }

        public override int GetHashCode() => name.GetHashCode();
    }
}
