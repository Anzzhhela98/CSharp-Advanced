using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;
namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private const string Model = "BMWX3";
        private const int HorsePower = 100;
        private const double CubicCentimeters = 100.0;
        private const string Name = "Migel";
        private const int MinParticipants = 2;

        private UnitCar unitCar;
        private UnitDriver unitDriver;
        private Dictionary<string, UnitDriver> driver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.race = new RaceEntry();
            this.driver = new Dictionary<string, UnitDriver>();
            this.unitCar = new UnitCar(Model, HorsePower, CubicCentimeters);
            this.unitDriver = new UnitDriver(Name, unitCar);
        }

        [TestCase(null)]
        //[TestCase("Migel", Model, HorsePower, CubicCentimeters)]
        public void AddDriverShouldThrowExeptionIfTheNameIsNullOrAlredyExistingDriver(UnitDriver driver)
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldThrowExeptionIfTheNameIsAlredyExisting()
        {
            this.driver.Add(this.unitDriver.Name, unitDriver);
            this.race.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(unitDriver));
        }

        //[Test]
        //public void CountOdDriversShouldIncrease()
        //{
        //    this.driver.Add(unitDriver.Name, unitDriver);

        //    int expectedCount = this.driver.Count;
        //    this.race.Counter=this.driver.Count

        //    Assert.AreEqual(expectedCount, actualCount);
        //}

        [Test]
        public void CheckIfCountIsSmallerFromMinParticipants()
        {
            this.driver.Add(unitDriver.Name, unitDriver);

            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePowerShouldBeReturnCorrectSum()
        {
            //Arramge
            UnitDriver firrstDriver = new UnitDriver(Name, new UnitCar(Model, HorsePower, CubicCentimeters));
            this.race.AddDriver(unitDriver);

            UnitDriver secondDriver = new UnitDriver("Jeni", new UnitCar("GX", 100, 23));
            this.race.AddDriver(secondDriver);

            UnitDriver thirdDriver = new UnitDriver("Didi", new UnitCar("GX", 100, 23));
            this.race.AddDriver(thirdDriver);

            //Act
            double expectedAverageHorsePower = 100;
            double actualAverage = this.race.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHorsePower, actualAverage);
        }
    }
}