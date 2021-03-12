namespace GenericCovidObserver.Model
{
    public class Person
    {
        private readonly int age;
        private bool isHealthy;

        public int Age
        {
            get { return age; }
        }
        public bool IsHealthy
        {
            get { return isHealthy; }
            set { isHealthy = value; }
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Person(int age, bool isHealthy, string name, string surname)
        {
            this.age = age;
            IsHealthy = isHealthy;
            Name = name;
            Surname = surname;
        }
    }
}
