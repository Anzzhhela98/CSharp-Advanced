using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new int[] { 1, 2, };

        [SetUp]
        public void SetUp()
        {
            this.database = new Database.Database(initialData);
        }

        [Test]
        public void TestIfConstructorsWorkCorectly()
        {
            int[] data = new int[] { 1, 2, 3 };
            this.database = new Database.Database(data);

            int expectedCount = data.Length;
            int actualCOunt = this.database.Count;

            Assert.AreEqual(expectedCount, actualCOunt);
        }

        [TestCase(new int[]  { 1, 2, 3, 4, 5,
                             6, 7, 8, 9, 10, 11,
                             12,13,14,15,16,17})]
        public void CheckIfConstructorThrowExeption(int[] data)
        {
            Assert.Throws<InvalidOperationException>(()
                => this.database = new Database.Database(data));
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            //Act
            this.database.Add(3);
            int expectedCount = 3;
            int actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldTrhrowExeptionWhenDatabaseIsFull()
        {
            //Arrange
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => this.database.Add(17));

        }

        [Test]
        public void RemoveShouldDecreaseCountWheSuccsess()
        {
            //Act
            this.database.Remove();

            //Arrange 
            int expected = 1;
            int actualCount = database.Count;

            //Assert
            Assert.AreEqual(expected, actualCount);

        }

        [Test]
        public void RemoveShoildThrowExeptionIfDataBecomesZeroCount()
        {
            this.database.Remove();
            this.database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => this.database.Remove());
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database.Database(expectedData);

            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}