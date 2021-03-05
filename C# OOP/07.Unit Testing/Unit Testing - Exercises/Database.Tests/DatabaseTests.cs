using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;

        //---------------- Fields ------------------
        private Database.Database database;

        //------------- Initialization -------------
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
        }

        //------------------ CONSTRUCTOR TESTS -------------------
        [Test]
        [TestCase(10)]
        [TestCase(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 1, 2, 3, 4, 5, 6)]
        public void ConstructorShouldInitializeDatabaseElementsCorrectly(params int[] numbers)
        {
            //Arrange
            this.database = new Database.Database(numbers);

            //Act
            int[] dbElements = this.database.Fetch();

            //Assert
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(dbElements[i], numbers[i]);
            }
        }

        [Test]
        public void ConstructorShouldInitializeDatabaseWithExactly16Elements()
        {
            //Arrange
            int[] array = new int[16];
            this.database = new Database.Database(array);

            //Act

            //Assert
            Assert.AreEqual(DatabaseCapacity, database.Count, "Array's capacity must be exactly 16 integers!");
        }

        //----------------- ADD OPERATION TESTS ------------------
        [Test]
        public void AddOperationShouldAddElementInTheNextFreeCell()
        {
            //Arrange

            //Act
            this.database.Add(255);

            //Assert
            Assert.AreEqual(1, database.Count, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void AddOperationExceeding16ElementsShouldThrowInvalidOperationException(params int[] arr)
        {
            //Arrange
            this.database = new Database.Database(arr);

            //Act

            //Assert
            Assert.That(() => this.database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        //----------------- FETCH OPERATION TESTS ----------------
        [Test]
        public void FetchOperationShouldReturnTheElementsAsArray()
        {
            //Arrange

            //Act
            int[] arr = this.database.Fetch();

            //Assert
            //Assert.That(() => this.database.Fetch(), Is.TypeOf<int[]>());
            Assert.That(arr, Is.TypeOf<int[]>());
        }

        //----------------- REMOVE OPERATION TESTS ---------------
        [Test]
        public void RemoveOperationShouldRemoveElementAtLastIndex()
        {
            //Arrange
            this.database = new Database.Database(5);

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(0, this.database.Count, "The collection is empty!");
        }

        [Test]
        public void RemoveOperationOnEmptyCollectionShouldThrowInvalidOperationException()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }
    }
}