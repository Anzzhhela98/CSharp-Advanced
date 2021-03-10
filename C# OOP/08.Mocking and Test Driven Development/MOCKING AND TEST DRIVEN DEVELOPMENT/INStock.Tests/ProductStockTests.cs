namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private const string Label = "Chia";
        private const decimal Price = 3.00M;
        private const int Quantity = 1;

        private IProduct product;
        private IProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();
            this.product = new Product(Label, Price, Quantity);
        }

        [Test]
        public void ConstructorShouldInitializeLabelCorrectly()
        {
            Assert.AreEqual("Chia", this.product.Label);
        }

        [Test]
        public void ConstructorShouldInitializeCollectionCorrectly()
        {
            int expected = 0;

            Assert.AreEqual(expected, this.productStock.Count);
        }

        [Test]
        public void PropertyCountShouldReturnCollectionCorectlyCount()
        {
            this.productStock.Add(this.product);

            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.productStock.Count);
        }

        [Test]
        public void IndexeShouldTakeItemOnIndex()
        {
            this.productStock.Add(this.product);
            IProduct extractedProduct = this.productStock[0];

            Assert.AreEqual(0, product.CompareTo(extractedProduct));
        }

        [Test]
        public void IndexerShouldSetItemOnIndex()
        {
            this.productStock.Add(this.product);

            IProduct newProduct = new Product("Banana", 15.50M, 1);
            this.productStock[0] = newProduct;

            Assert.AreEqual(0, newProduct.CompareTo(this.productStock[0]));
        }

        [Test]
        public void IndexeShouldThrowIndexOutOfRangeExceptionInAttemptToTakeProductOnInvalidIndex()
        {
            //Assert.Throws<IndexOutOfRangeException>(() => this.productStock[0].CompareTo(this.productStock[3]));
            Assert.That(() => this.productStock[2], Throws.TypeOf<IndexOutOfRangeException>());
        }
        [Test]
        public void AddMethodShouldAddNewProductInCOllection()
        {
            this.productStock.Add(this.product);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.productStock.Count);
        }

        [Test]
        public void AddMethodShouldThrowExeptioWhenTryToAddExistingProduct()
        {
            this.productStock.Add(this.product);
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Add(this.product);
            });
        }

        [Test]
        public void ContainsMethodShouldCheckIfProductIsAlredyExistAndReturnTrue()
        {
            this.productStock.Add(this.product);

            bool expectedResult = this.productStock.Contains(product);
            Assert.AreEqual(expectedResult, true);
        }

        [Test]
        public void ContainsMethodShouldCheckIfProductIsAlredyExistAndReturnFalse()
        {
            bool expectedResult = this.productStock.Contains(product);

            Assert.AreEqual(expectedResult, false);
        }

        [Test]
        public void FindByMethodShouldReturnTheProductInCurrentPosition()
        {
            this.productStock.Add(this.product);

            IProduct expectedProduct = this.productStock.Find(0);

            Assert.AreEqual(expectedProduct.Label, this.product.Label);
        }

        [TestCase(9)]
        [TestCase(-3)]
        public void FindByMethodShouldReturnTheProductInCurrentPosition(int index)
        {
            this.productStock.Add(this.product);


            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(index);
            });
        }

        [TestCase(3.00)]
        public void FindAllByPriceShouldReturnAllProductsWithThathPrice(double price)
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 3.00M, 1);
            this.productStock.Add(chia);
            this.productStock.Add(banana);

            IEnumerable<IProduct> expected = new List<IProduct>() { chia, banana };
            IEnumerable<IProduct> actual = this.productStock.FindAllByPrice(price);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(4.00)]
        public void FindAllByPriceShouldReturnEmptyCollectionWithThathPrice(double price)
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 3.00M, 1);
            this.productStock.Add(chia);
            this.productStock.Add(banana);

            IEnumerable<IProduct> expected = new List<IProduct>() { chia, banana };
            IEnumerable<IProduct> actual = this.productStock.FindAllByPrice(price);

            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestCase(1)]
        public void FindAllByQuantityShouldReturnAllProductsWithThathPrice(int quantity)
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 3.00M, 1);

            this.productStock.Add(chia);
            this.productStock.Add(banana);

            IEnumerable<IProduct> expected = new List<IProduct>() { chia, banana };
            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(quantity);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(2)]
        public void FindAllByQuantityeShouldReturnEmptyCollectionWithThathPrice(int quantity)
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 3.00M, 1);

            this.productStock.Add(chia);
            this.productStock.Add(banana);

            IEnumerable<IProduct> expected = new List<IProduct>() { chia, banana };
            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(quantity);

            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestCase(3.00, 5.00)]
        public void FindAllInRangeShouldReturnAllProductPriceInThGivenRange(double low, double hi)
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 4.00M, 1);
            IProduct orange = new Product("Orange", 5.00M, 1);

            this.productStock.Add(chia);
            this.productStock.Add(banana);
            this.productStock.Add(orange);

            IEnumerable<IProduct> expected = new List<IProduct>() { chia, banana, orange };
            IEnumerable<IProduct> actual = this.productStock.FindAllInRange(low, hi);


            CollectionAssert.AreEqual(expected, actual);
        }
        [TestCase(7.00, 8.00)]
        public void FindAllInRangeShouldReturnEmptyCollectionInThGivenRange(double low, double hi)
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 4.00M, 1);
            IProduct orange = new Product("Orange", 5.00M, 1);

            this.productStock.Add(chia);
            this.productStock.Add(banana);
            this.productStock.Add(orange);

            IEnumerable<IProduct> expected = new List<IProduct>() { chia, banana, orange };
            IEnumerable<IProduct> actual = this.productStock.FindAllInRange(low, hi);


            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestCase("Chia")]
        public void FindByLabelMethodShouldReturnTheSameLabelWichIsLookingFor(string label)
        {
            CreateProduct();

            IProduct expectedProduct = this.productStock.FindByLabel(label);

            Assert.AreEqual(expectedProduct.Label, this.product.Label);
        }

        [TestCase("Cake")]
        public void FindByLabelMethodShouldThrowArgumentException(string label)
        {
            CreateProduct();

            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.FindByLabel(label);
            });
        }

        [Test]
        public void FindMostExpensiveProductsMethodShouldReturnMostExpensiveProduct()
        {
            CreateProduct();

            IProduct expectedProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreEqual(expectedProduct.Price, 4.00);
        }

        [Test]
        public void FindMostExpensiveProductsMethodShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.productStock.FindMostExpensiveProduct();
            });
        }
        [Test]
        public void GetEnumeratorProductShouldReturnAllProductsInStock()
        {
            CreateProduct();

            var result = this.productStock.ToList();

            Assert.That(result.GetEnumerator(), Is.EqualTo("Chia"));
            Assert.That(result[1].Label, Is.EqualTo("Banana"));
        }

        [Test]
        public void RemoveMethodShouldRemoveCorectlyAndReturnTrue()
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 4.00M, 1);

            this.productStock.Add(chia);
            this.productStock.Add(banana);

            Assert.That(this.productStock.Remove(banana), Is.EqualTo(true));

            Assert.AreEqual(1, this.productStock.Count);
        }

        [Test]
        public void RemoveMethodShouldRemoveCorectlyAndReturnFalse()
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 4.00M, 1);

            this.productStock.Add(chia);

            Assert.That(this.productStock.Remove(banana), Is.EqualTo(false));

            Assert.AreEqual(1, this.productStock.Count);
        }

        private void CreateProduct()
        {
            IProduct chia = new Product(Label, Price, Quantity);
            IProduct banana = new Product("Banana", 4.00M, 1);

            this.productStock.Add(chia);
            this.productStock.Add(banana);
        }
    }
}
