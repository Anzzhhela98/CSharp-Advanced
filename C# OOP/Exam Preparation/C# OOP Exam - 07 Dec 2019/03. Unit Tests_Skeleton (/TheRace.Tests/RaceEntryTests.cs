using NUnit.Framework;
using System;

namespace TheRace.Tests
{

    public class RaceEntryTests
    {

        private UnitRider rider;
        private UnitMotorcycle unitMotorcycle = new UnitMotorcycle("D", 12, 34);
        new RaceEntry raceEntry;


        [SetUp]
        public void Setup()
        {
            this.rider = new UnitRider("bob", this.unitMotorcycle);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, unitMotorcycle));
        }

        [TestCase(null)]
        public void AddRiderShouldThrowInvalidOperationException(UnitRider unit)
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(unit));
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationException()
        {
            this.raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(rider));
        }

        [Test]
        public void AddRiderShouldAddCorectly()
        {
            this.raceEntry.AddRider(rider);
            this.raceEntry.AddRider(new UnitRider("Bob", unitMotorcycle));

            Assert.AreEqual(2, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowInvalidOperationExceptionIfRidersAreLessThanMinimum()
        {
            this.raceEntry.AddRider(rider);
           

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldREturnCorrectResult()
        {
            this.raceEntry.AddRider(rider);
            this.raceEntry.AddRider(new UnitRider("Bob", unitMotorcycle));

           
            Assert.AreEqual(12, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}