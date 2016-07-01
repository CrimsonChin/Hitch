using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Hitch.UnitTest.Classes;

namespace Hitch.UnitTest
{
    [TestClass]
    public class ExtensionsTest
    {
        private IList<Person> _people;

        [TestInitialize]
        public void TestInit()
        {
            _people = new List<Person>
            {
                new Person("Jonathan", 28),
                new Person("Jonathan", 22),
                new Person("Barry", 48),
                new Person("Tina", 36)
            };
        }

        [TestMethod]
        public void Where_returns_two_people_when_found_in_collection()
        {
            // Arrange
            const string name = "Jonathan";

            // Act
            var people = _people.Where(x => x.Name == name).ToList();

            // Assert
            Assert.AreEqual(2, people.Count);
        }

        [TestMethod]
        public void Where_returns_one_person_when_found_in_collection_with_more_complex_predicate()
        {
            // Arrange
            const string name = "Jonathan";
            const short age = 28;

            // Act
            var people = _people.Where(x => x.Name == name && x.Age == age).ToList();

            // Assert
            Assert.AreEqual(1, people.Count);
            Assert.AreEqual(name, people[0].Name, "Expected name of Jonathan");
            Assert.AreEqual(age, people[0].Age, "Expected age of 28");
        }

        [TestMethod]
        public void Where_returns_empty_collection_when_no_match_is_found()
        {
            // Arrange
            const string name = "safasdf";

            // Act
            var people = _people.Where(x => x.Name == name).ToList();

            // Assert
            Assert.IsNotNull(people);
            Assert.AreEqual(0, people.Count);
        }

        [TestMethod]
        public void FirstOrDefault_returns_default_if_collection_is_empty()
        {
            // Arrange
            _people = new List<Person>();

            // Act
            var actual = _people.FirstOrDefault();

            // Assert
            Assert.AreEqual(default(Person), actual);
        }

        [TestMethod]
        public void FirstOrDefault_returns_first_item_when_items_present()
        {
            // Arrange
            const string name = "Jonathan";
            const short age = 28;

            // Act
            var actual = _people.FirstOrDefault();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(name, actual.Name, "Expected name of Jonathan");
            Assert.AreEqual(age, actual.Age, "Expected age of 28");
        }

        [TestMethod]
        public void FirstOrDefault_with_predicate_returns_default_if_no_match_is_found()
        {
            // Arrange
            const string name = "safasdf";

            // Act
            var actual = _people.FirstOrDefault(x => x.Name == name);

            // Assert
            Assert.AreEqual(default(Person), actual);
        }

        [TestMethod]
        public void FirstOrDefault_with_predicate_returns_first_match_with_multiple_matches_present()
        {
            // Arrange
            const string name = "Jonathan";
            const short age = 28;

            // Act
            var actual = _people.FirstOrDefault(x => x.Name == name);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(name, actual.Name, "Expected name of Jonathan");
            Assert.AreEqual(age, actual.Age, "Expected age of 28");
        }
    }
}
