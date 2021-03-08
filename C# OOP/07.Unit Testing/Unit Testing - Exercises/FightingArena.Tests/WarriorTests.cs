using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private Warrior warrior;
        private const string Name = "Varian";
        private const int Damage = 105;
        private const int Hp = 150;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(Name, Damage, Hp);
        }

        [Test]
        public void ConstructorShouldCreateInstanceOfWarrior()
        {
            Assert.IsNotNull(this.warrior);
        }

        [TestCase(null, Damage, Hp)]
        [TestCase("    ", Damage, Hp)]
        [TestCase(Name, 0, Hp)]
        [TestCase(Name, -1, Hp)]
        [TestCase(Name, Damage, -1)]
        public void ConstructorShouldThrowExeption(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void AttackOperationShouldDecrementWarriorHP()
        {
            Warrior otherWarrior = new Warrior("Geno", 10, 150);
            int expectedHP = 140;

            this.warrior.Attack(otherWarrior);

            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [TestCase(1)]
        [TestCase(20)]
        [TestCase(29)]
        public void AttackOperationShpouldThrowInvalidOperationExeptionIfTryToAttackWithLowHP(int hp)
        {
            Warrior otherWarrior = new Warrior("Geno", 10, hp);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(otherWarrior));
        }

        [TestCase(1)]
        [TestCase(20)]
        [TestCase(29)]
        public void AttackOperationShpouldThrowInvalidOperationExeptionIfTryToAttackWithLowHPOtherWarrior(int hp)
        {
            this.warrior = new Warrior(Name, Damage, hp);
            Warrior otherWarrior = new Warrior("Geno", 10, 120);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(otherWarrior));
        }
        [TestCase(40, 60)]
        public void AttackOperationShpouldThrowInvalidOperationExeptionIfTryToAttackWithBiggerDamage(int hp, int damage)
        {
            this.warrior = new Warrior(Name, Damage, hp);
            Warrior otherWarrior = new Warrior("Geno", damage, hp);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(otherWarrior));
        }

        [TestCase("Geno", 50, 40)]
        public void TestWarriorAttackIfDefendHpIsLessThanDamage(string name, int damage, int hp)
        {
            Warrior otherWarrior = new Warrior(name, damage, hp);

            int expectedHP = 0;
            this.warrior.Attack(otherWarrior);
            Assert.AreEqual(expectedHP, otherWarrior.HP);
        }
    }
}