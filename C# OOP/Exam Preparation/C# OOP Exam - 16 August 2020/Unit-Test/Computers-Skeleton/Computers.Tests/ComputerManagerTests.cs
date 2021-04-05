using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Hp", "Device200", 2300M);
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void ConstructorWorkCorrect()
        {
            Computer computer = new Computer("HP", "230", 1000);
            Assert.IsNotNull(computer);
        }

        [Test]
        public void CountWorkCorrect()
        {
            this.computerManager.AddComputer(this.computer);
            Assert.AreEqual(1, this.computerManager.Count);
        }

        [Test]
        public void IReadOnlyCollectionWorkCorrect()
        {
            Assert.IsNotNull(computerManager.Computers);
        }

        [TestCase(null)]
        public void AddComputerShouldThrowArgumentNullException(Computer computer)
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputerShouldAddCorrect()
        {
            this.computerManager.AddComputer(computer);

            Assert.AreEqual(1, this.computerManager.Computers.Count);
        }

        [Test]
        public void AddComputerShouldThrowArgumentException()
        {
            this.computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(computer));
        }

        [TestCase(null)]
        public void GetComputerShouldThrowArgumentNullException(string value)
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(value, "Di230"));
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer("HP", value));
        }

        [Test]
        public void GetComputerShouldThrowArgumenExceptionIfCOmputerDoesntExist()
        {
            Computer computer = new Computer("HP", "Device200", 700);
            this.computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Lenovo", "2030"));
        }

        [Test]
        public void GetComputerShouldReturnCorrect()
        {
            Computer computer = new Computer("HP", "Device200", 700);
            this.computerManager.AddComputer(computer);

            Assert.AreEqual(computer, computerManager.GetComputer("HP", "Device200"));
        }

        [TestCase("HP", "Device200")]
        public void GetComputerShouldThrowArgumentException(string manufacture, string model)
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer(manufacture, model));
        }

        [Test]
        public void RemoveComputer()
        {
            Computer computer = new Computer("HP", "Device200", 700);
            this.computerManager.AddComputer(computer);

            Assert.AreEqual(computer, computerManager.RemoveComputer("HP", "Device200"));
        }

        [TestCase(null)]
        public void RemoveComputer(string value)
        {
            Computer computer = new Computer("HP", "Device200", 700);
            this.computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(()=>this.computerManager.RemoveComputer(value, "J230"));
            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer("HP", value));
        }

        [Test]
        public void GetComputersByManufacturer()
        {
            Computer computer1 = new Computer("HP", "Device200", 700);
            Computer computer2 = new Computer("HP", "D320", 700);
            Computer computer3 = new Computer("Lenovo", "D320", 700);
            this.computerManager.AddComputer(computer1);
            this.computerManager.AddComputer(computer2);
            this.computerManager.AddComputer(computer3);

            ICollection<Computer> expectedComputers = 
                this.computerManager.Computers.Where(x => x.Manufacturer == "HP").ToList();

            Assert.AreEqual(expectedComputers, computerManager.GetComputersByManufacturer("HP"));
        }

        [TestCase(null)]
        public void GetComputersByManufacturer(string manufacture)
        {
            Assert.Throws<ArgumentNullException>(()=> computerManager.GetComputersByManufacturer(manufacture));
        }
    }
}