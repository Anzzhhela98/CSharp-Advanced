using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private const int DatabaseCapacity = 16;

        private Person[] people;
        private ExtendedDatabase.ExtendedDatabase extendedDB;

        [SetUp]
        public void Setup()
        {
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase();
            this.people = new Person[]
            {
            new Person(2636, "Hihi"),
            new Person(2635, "Lili"),
            new Person(2634, "Kiki"),
            new Person(2633, "Didi"),
            new Person(2632, "Vivi"),
            new Person(2631, "Bibi"),
            new Person(2630, "Titi"),
            new Person(2629, "Jiji"),
            new Person(2628, "Gigi"),
            new Person(2627, "Sisi"),
            new Person(2626, "Pipi"),
            new Person(2625, "Zizi"),
            new Person(2624, "Fifi"),
            new Person(2623, "Tedi"),
            new Person(2622, "Simi"),
            new Person(2621, "Mimi"),
            };
        }

        [Test]
        public void ConstructorInitializeThePeopleInDataWithExactly16People()
        {
            //Arrange
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase(people);

            //Assert
            Assert.AreEqual(DatabaseCapacity, extendedDB.Count);
        }

        [Test]
        public void CheckIfArrayIsOverCapacity()
        {
            this.people = new Person[17];
            //Assert
            Assert.Throws<ArgumentException>(() =>
            new ExtendedDatabase.ExtendedDatabase(people));

        }

        [Test]
        public void ThrowExeptionIfTryToAddMoreThanDatabaseCapacity()
        {
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase(this.people);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => this.extendedDB.Add(new Person(3698, "Jizi")));
        }
        [Test]
        public void ThrowExeptionIfTryToAddSamePerosnWithAlredyExistingName()
        {
            this.extendedDB.Add(new Person(2621, "Mimi"));

            Assert.Throws<InvalidOperationException>(() => this.extendedDB.Add(new Person(7979, "Mimi"))); ;
        }
        [Test]
        public void ThrowExeptionIfTryToAddSamePerosnWithAlredyExistingId()
        {
            this.extendedDB.Add(new Person(2621, "Mimi"));

            Assert.Throws<InvalidOperationException>(() => this.extendedDB.Add(new Person(2621, "Jana"))); ;
        }

        [Test]
        public void RemoveOperationShouldReturExeption()
        {
            //Arrange
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase();

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.extendedDB.Remove());
        }

        [Test]
        public void RemoveShouldRemoveAtLastIndex()
        {
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase(new Person(26231, "Jino"));

            this.extendedDB.Remove();

            int expectedCount = 0;
            int actualCount = this.extendedDB.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FindByUserNameShouldReturnMatchingName()
        {
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase(this.people);

            Person actualPerson = people[15];
            Person expectedPerson = this.extendedDB.FindByUsername("Mimi");

            Assert.AreEqual(expectedPerson, actualPerson);
        }
        [Test]
        public void FindByUserNameShouldReturnMatchingNameIsFalse()
        {
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase(this.people);

            Person actualPerson = people[15];

            Assert.Throws<InvalidOperationException>(() => this.extendedDB.FindByUsername("Desi"));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameShouldThrowArgumentNullExceptionWhenTheNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDB.FindByUsername(name));
        }

        [TestCase(-1)]
        public void FindByUserIDShouldThrowArgumentOutOfRangeExceptionWhenTheIdIsLEssThanZero(int Id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDB.FindById(Id));
        }

        [TestCase(2646)]
        [TestCase(000000)]
        [TestCase(123313540)]
        public void FindByUserIDShouldThrowInvalidOperationExceptionTheIdDoesntExist(int Id)
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDB.FindById(Id));
        }
        [Test]
        public void FindByIdShouldReturnMatchingId()
        {
            this.extendedDB = new ExtendedDatabase.ExtendedDatabase(this.people);

            Person actualPerson = people[15];
            Person expectedPerson = this.extendedDB.FindById(2621);

            Assert.AreEqual(expectedPerson, actualPerson);
        }
    }
}