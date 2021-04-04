namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            this.fish = new Fish("Nemo");
            this.aquarium = new Aquarium("Deep", 2);
        }


        [Test]
        public void IfFishConstructorWorks()
        {
            this.aquarium.Add(fish);
            var expectedCount = 1;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [TestCase(null)]
        public void IfNameIsNullOrEmty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(name, 3));
        }

        [Test]
        public void AddSHouldThrowInvalidOperationException()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.Add(new Fish("Dino"));
            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("Seno")));
        }

        [Test]
        public void RemoveFishSHouldThrowInvalidOperationException()
        {

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish(this.fish.Name));
        }

        [Test]
        public void RemoveFishShouldRemoveCoreclty()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.RemoveFish(this.fish.Name);

            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void SellFishSHouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish(this.fish.Name));
        }

        [Test]
        public void SellFishSHouldSetAvaillableToFalse()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.SellFish(fish.Name);

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void Report()
        {
            this.aquarium.Add(this.fish);

            string expected = $"Fish available at {this.aquarium.Name}: {this.fish.Name}";

            Assert.AreEqual(expected, this.aquarium.Report());
        }
    }
}
