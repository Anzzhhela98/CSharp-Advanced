namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        private const string Label = "Chia";
        private const decimal Price = 3.00M;
        private const int Quantity = 1;

        private IProduct product;

        [SetUp]
        public void SetUp()
        {
            this.product = new Product(Label, Price, Quantity);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectlyLabel()
        {
            Assert.AreEqual("Chia", this.product.Label);
        }
        [Test]
        public void ConstructorShouldInitializeCorrectlyPrice()
        {
            Assert.AreEqual(3.00M, this.product.Price);
        }
        [Test]
        public void ConstructorShouldInitializeCorrectlyQuantity()
        {
            Assert.AreEqual(1, this.product.Quantity);
        }

        [Test]
        public void CompareToShouldCompare2ProductsByLabelAndReturn0()
        {
            IProduct product = new Product(Label, Price, Quantity);
            Assert.AreEqual(0, this.product.CompareTo(product));
        }

        [Test]
        public void CompareToShouldCompare2ProductsByLabelAndReturn1()
        {
            IProduct product = new Product("Banana", 2.00M, 1);
            Assert.AreEqual(1, this.product.CompareTo(product));
        }
    }
}