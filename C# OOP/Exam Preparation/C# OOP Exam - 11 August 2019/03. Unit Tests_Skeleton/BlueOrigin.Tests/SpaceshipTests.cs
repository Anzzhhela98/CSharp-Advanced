namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship("Oriom", 10);
        }

        [Test]
        public void NameShouldSetCorrectly()
        {
            Assert.AreEqual("Oriom", spaceship.Name);
        }

        [Test]
        public void NameShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));
        }

        [Test]
        public void CountShouldSetCorrectly()
        {
            Assert.AreEqual(0, this.spaceship.Count);
        }
        [Test]
        public void CapacityShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("JZ", -1));
        }

        [Test]
        public void CapacityShouldSetCorrectly()
        {
            Assert.AreEqual(10, this.spaceship.Capacity);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfIsFull()
        {
            this.spaceship = new Spaceship("JZ", 1);
            this.spaceship.Add(new Astronaut("Sa", 23));

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("SHi", 23)));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfAstronautAlredyExist()
        {
            this.spaceship.Add(new Astronaut("SHi", 23));

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("SHi", 23)));
        }

        [Test]
        public void RemoveMethodShouldReturnTrue()
        {
            this.spaceship.Add(new Astronaut("Sa", 23));

            Assert.IsTrue(this.spaceship.Remove("Sa"));
        }

        [Test]
        public void RemoveMethodShouldReturnFalse()
        {
            this.spaceship.Add(new Astronaut("Sa", 23));

            Assert.IsFalse(this.spaceship.Remove("JZ"));
        }
    }
}