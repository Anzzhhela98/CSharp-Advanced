using System;
using System.Collections.Generic;
using NUnit.Framework;


public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {
        this.heroRepository = new HeroRepository();
        this.hero = new Hero("John", 15);
    }

    [Test]
    public void CreateShouldThrowArgumentNullExceptionIfHeroIsNull()
    {
        Hero hero = null;
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(hero));
    }

    [Test]
    public void CreateShouldAddHero()
    {
        this.heroRepository.Create(this.hero);
        Assert.AreEqual(1, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateShouldThrowInvalidOperationException()
    {
        this.heroRepository.Create(this.hero);
        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(new Hero("John", 63)));
    }

    [TestCase(null)]
    [TestCase(" ")]
    public void RemoveShpuldThrowArgumentNullExceptionIfNameIsNull(string name)
    {
        this.heroRepository.Create(this.hero);
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(name));
    }

    [Test]
    public void RemoveShouldRemoveCorect()
    {
        this.heroRepository.Create(this.hero);
        this.heroRepository.Remove("John");
        var actualResult = this.heroRepository.Heroes.Count;

        Assert.AreEqual(0, actualResult);
    }

    [Test]
    public void GetHeroWithHighestLevelSgouldReturnCorect()
    {
        Hero hero2 = new Hero("Bani", 23);

        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero2);

        Hero actual = heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual(hero2, actual);
    }

    [Test]
    public void GetHeroWithGivenName()
    {
        Hero hero2 = new Hero("Bani", 23);

        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero2);

        Hero actual = heroRepository.GetHero("Bani");
        Assert.AreEqual(hero2.Name, actual.Name);
    }

    [Test]
    public void PropertyTest()
    {

        this.heroRepository.Create(this.hero);
        var expectedResult = 1;

        Assert.AreEqual(expectedResult, this.heroRepository.Heroes.Count);
    }
}