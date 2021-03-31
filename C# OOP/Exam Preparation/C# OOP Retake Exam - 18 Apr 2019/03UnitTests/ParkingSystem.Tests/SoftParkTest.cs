namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.car = new Car("MiniCouper", "986565");
        }
        [Test]
        public void TestIfCarConstructor()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void ParkCarShouldThrowArgumentExceptionIfSpotDoesntExist()
        {

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("B65", this.car));
        }

        [Test]
        public void ParkCarShouldThrowArgumentExceptionIfSpotIsAlredyExist()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A1", this.car));
        }

        [Test]
        public void ParkCarShouldThrowInvalidOperationExceptionIfRegisterNumberExist()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("A2", this.car));
        }


        [Test]
        public void ParkCarShouldAddCarInParking()
        {
            this.softPark.ParkCar("A1", this.car);

            var actual = this.softPark.Parking["A1"].RegistrationNumber == "986565";
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RemoveCarShouldThrowArgumentExceptionIfSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A63", this.car));
        }

        [Test]
        public void RemoveCarShouldThrowArgumentExceptionIfGivenCarOnTheSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A1", this.car));
        }

        [Test]
        public void RemoveCarShouldRemovecorrect()
        {
            this.softPark.ParkCar("A1", this.car);

            this.softPark.RemoveCar("A1", this.car);

            var expected = this.softPark.Parking["A1"]==null;
            Assert.IsTrue(expected);
        }

    }
}