namespace Hitch.UnitTest.Classes
{
    internal class Person
    {
        public Person(string name, short age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }

        public short Age { get; }
    }
}
