// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
  //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;  

    [TestFixture]
    public class StageTests
    {
        private Song song;
        private Performer performer;
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            this.performer = new Performer("Sisi", "Smith", 25);
            this.song = new Song("Fly", new TimeSpan(12, 23, 62));
            this.stage = new Stage();
        }

        [Test]
        public void AddPerformerShouldThrowExceptionInvalidAge()
        {
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("JZ", "Smith", 16)));
        }

        [Test]
        public void AddPerformerShouldAddCorect()
        {

            this.stage.AddPerformer(new Performer("JZ", "Smith", 20));
            this.stage.AddPerformer(new Performer("Seina", "Smith", 30));

            Assert.AreEqual(2, this.stage.Performers.Count);
        }

        [Test]
        public void AddPerformerShouldTrowException()
        {
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(performer));
        }
    }
}