namespace DefiningClasses
{
    public class Person
    {
        private int age;
        private string name;

        public Person()
        {
            this.Age = 1;
            this.Name = "No name";
        }
        public Person(int age) : this()
        {
            this.Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            this.Name = name;
        }


        public int Age { get; set; }
        public string Name { get; set; }
    }
}