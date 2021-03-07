using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;
        private const string Make = "BMW";
        private const string Model = "BMWX3";
        private const double FuelConsumption = 12;
        private const double FuelAmount = 0;
        private const double FuelCapacity = 70;
        [SetUp]
        public void Setup()
        {
            this.car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void ConstructorSetAmountDeafaultZero()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void ConstructorShpuldInitalizeCarCorectly()
        {

            Assert.IsNotNull(this.car);
        }

        [TestCase(null)]
        [TestCase()]
        public void IfMakeIsNullOrEmptyShouldThrowExeption(string make)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(make, Model, FuelConsumption, FuelCapacity));
        }

        [TestCase(null)]
        [TestCase()]
        public void IfModelIsNullOrEmptyShouldThrowExeption(string model)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(Make, model, FuelConsumption, FuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-3)]
        public void IfFuelConsumptionIsZeroOrLessThanZeroShouldThrowExeption(double fuelConsumption)
        {

            Assert.Throws<ArgumentException>(() => this.car = new Car(Make, Model, fuelConsumption, FuelCapacity));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void IfFuelCapacityIsZeroOrLessThanZeroShouldThrowExeption(double fueslCapacity)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(Make, Model, FuelConsumption, fueslCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelAmountCannotBeZeroOrLessThanZeroShouldThrowExeption(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [TestCase(50)]
        [TestCase(30)]
        public void RefuelOperationShouldSetFuelAmountCorrectly(double fuel)
        {
            this.car.Refuel(fuel);
            Assert.AreEqual(fuel, this.car.FuelAmount);
        }
        [TestCase(280)]
        public void RefuelOperationCannotBeMoreThanCapacity(double refuel)
        {
            double ecpected = 70;
            this.car.Refuel(refuel);

            Assert.AreEqual(ecpected, this.car.FuelAmount);
        }
        [TestCase(20)]
        public void DriveOperationShouldDecrementFuelAmount(double distance)
        {
            this.car.Refuel(70);
            this.car.Drive(distance);
            double expectedResult = 67.6;

            Assert.AreEqual(expectedResult, this.car.FuelAmount);
        }
        [TestCase(2000)]
        public void DistanceISMorethanFuelAmount(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance));
        }

    }
}

