using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault collection;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("JZ", "9663");
            this.collection = new BankVault();
        }

        [Test]
        public void AddItemShouldThrowArgumentExceptionIfCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.collection.AddItem("A12", this.item));
        }

        [Test]
        public void AddItemShouldThrowArgumentExceptionIfCellsIsTaken()
        {
            collection.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => this.collection.AddItem("A1", new Item("Si", "36")));
        }

        [Test]
        public void AddItemShouldThrowInvalidOperationExceptionIWhenItemIdAlredyExist()
        {
            collection.AddItem("A1", this.item);
            Assert.Throws<InvalidOperationException>(() => this.collection.AddItem("A2", this.item));
        }

        [Test]
        public void RemoveItemShouldThrowArgumentExceptionIfCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.collection.RemoveItem("A12", this.item));
        }

        [Test]
        public void RemoveItemShouldThrowArgumentExceptionIfItemDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.collection.RemoveItem("A1", this.item));
        }

        [Test]
        public void RemoveItemShouldRemoveCorrectly()
        {
            this.collection.AddItem("A1", this.item);

            this.collection.RemoveItem("A1", this.item);

            Assert.IsNull(collection.VaultCells["A1"]);

        }

    }
}