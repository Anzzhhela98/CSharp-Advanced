// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

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
        public void ConstructorShouldWorkCorect()
        {
            Assert.IsNotNull(this.performer);
        }

        [Test]
        public void IReadOnlyPerformers()
        {
            Assert.IsNotNull(this.stage.Performers);
        }

        [TestCase(null)]
        public void AddPerformerShouldThrowArgumentNullException(Performer performer)
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformerShouldThrowArgumenExceptionIfPerformerAgeAreLessThan18()
        {
            Performer performer = new Performer("DI", "ZI", 16);
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformerShouldAddCorect()
        {
            Performer performer = new Performer("DI", "ZI", 26);
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(this.performer);

            int expectedCount = 2;
            Assert.AreEqual(expectedCount, this.stage.Performers.Count);
        }

        [TestCase(null)]
        public void AddSongShouldThrowArgumentNullException(Song song)
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(song));
        }

        [Test]
        public void AddSongShouldThrowArgumenExceptionIfDurationIsLessThanOneMinute()
        {
            Song song = new Song("FLy", new TimeSpan(0, 0, 30));
            Assert.Throws<ArgumentException>(() => this.stage.AddSong(song));
        }

        [Test]
        public void AddSongShouldAddCorect()
        {
            Song song = new Song("FLy", new TimeSpan(0, 1, 30));
            this.stage.AddSong(song);
            /* Assert.AreEqual(1, ); *///?????
        }

        [TestCase(null, "Jesi")]
        [TestCase("Fly", null)]
        public void AddSongToPerformerShouldThrowArgumentNullException(string songName, string performerName)
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName, performerName));
        }

        [Test]
        public void AddSongToPerformerShouldAddCorect()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.song);


            string expected =   $"{song} will be performed by {performer}";
            Assert.AreEqual(expected, stage.AddSongToPerformer(song.Name, performer.FullName));

            Assert.AreEqual(1, this.performer.SongList.Count);
        }

        [Test]
        public void Play()
        {
            this.stage.AddPerformer(this.performer);
            this.performer.SongList.Add(this.song);

            var songsCount = this.stage.Performers.Sum(p => p.SongList.Count());

            string expected = $"{this.stage.Performers.Count} performers played {songsCount} songs";

            Assert.AreEqual(expected, this.stage.Play());
        }
    }
}