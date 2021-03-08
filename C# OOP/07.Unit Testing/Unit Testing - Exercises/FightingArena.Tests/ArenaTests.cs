using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void EnrollShouldEnrrolWarriorCorrectly()
        {
            Warrior firstWarrior = new Warrior("Django", 10, 150);
            Warrior secondWarrior = new Warrior("Djeni", 10, 150);

            List<Warrior> expectedWarriors = new List<Warrior> { firstWarrior, secondWarrior };

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            Assert.AreEqual(expectedWarriors, arena.Warriors);
        }

        [TestCase("Django", 50, 100)]
        public void TryToEnrrolExistingWarriorThrowExeption(string name, int damage, int Hp)
        {
            //Arrange & Act
            Warrior warrior = new Warrior(name, damage, Hp);
            this.arena.Enroll(warrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [TestCase("Django", 50, 100)]
        public void EnrollShouldAddWarrior(string name, int damage, int Hp)
        {
            Warrior warrior = new Warrior(name, damage, Hp);
            this.arena.Enroll(warrior);

            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [TestCase("Django", "Deina")]
        public void FightOperationShouldThrowExeptionIfTheWarriorsAreNotExist(string attackerName, string defenderName)
        {
            Warrior warrior = new Warrior("attackerName", 10, 150);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attackerName, defenderName));
        }

        [TestCase("Django", "Deina")]
        public void FightOperationShouldMadeAttack(string attackerName, string defenderName)
        {
            Warrior firtWarrior = new Warrior(attackerName, 10, 150);
            Warrior secondWarror = new Warrior(defenderName, 5, 250);

            this.arena.Enroll(firtWarrior);
            this.arena.Enroll(secondWarror);

            int expected = firtWarrior.HP - secondWarror.Damage;
            this.arena.Fight(attackerName, defenderName);

            Assert.AreEqual(expected, firtWarrior.HP);


        }
    }
}
