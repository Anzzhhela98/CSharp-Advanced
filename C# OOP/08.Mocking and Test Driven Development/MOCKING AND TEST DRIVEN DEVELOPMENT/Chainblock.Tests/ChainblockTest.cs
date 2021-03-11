using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTest
    {
        private const int Id = 98;
        private const TransactionStatus Transactionstatus = TransactionStatus.Successfull;
        private const string From = "Anzhela";
        private const string To = "Ivaylo";
        private const double Amount = 100;

        private ITransaction transaction;
        private IChainblock allTransactions;
        [SetUp]
        public void SetUp()
        {
            this.transaction = new Transaction(Id, Transactionstatus, From, To, Amount);
            this.allTransactions = new Chainblock();
        }

        [Test]
        public void ContainseShouldCheckIfTransactionIsAlredyAddedAndReturnTrue()
        {
            this.allTransactions.Add(this.transaction);

            Assert.IsTrue(this.allTransactions.Contains(this.transaction));
        }

        [Test]
        public void ContainseShouldCheckIfTransactionIsNotAddedAndReturnFalse()
        {
            this.allTransactions.Add(this.transaction);

            Assert.IsFalse(this.allTransactions.Contains(new Transaction(96, TransactionStatus.Failed, "Ivana", "Ivan", 1020)));
        }

        [Test]
        public void AddShouldAddTransactonIfIsNotAlredyExist()
        {
            this.allTransactions.Add(this.transaction);

            Assert.AreEqual(98, transaction.Id);
            Assert.AreEqual(1, this.allTransactions.Count);
        }

        [Test]
        public void AddShouldNotAddTransactonIfAlredyExist()
        {
            this.allTransactions.Add(this.transaction);

            Assert.Throws<ArgumentException>(() =>
            {
                this.allTransactions.Add(this.transaction);
            });

            Assert.AreEqual(1, this.allTransactions.Count);
        }

        [Test]
        public void ContainseByIdShouldCheckIfIsAddedAndReturnTrue()
        {
            this.allTransactions.Add(this.transaction);

            Assert.IsTrue(this.allTransactions.Contains(Id));
        }

        [Test]
        public void ContainseByIdShouldCheckIfIsNotAddedAndReturnFalse()
        {
            this.allTransactions.Add(this.transaction);

            Assert.IsFalse(this.allTransactions.Contains(96));
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeStatusIfTransactonIsAlredyExist()
        {
            this.allTransactions.Add(this.transaction);
            TransactionStatus oldTransactionType = this.transaction.Status;

            this.allTransactions.ChangeTransactionStatus(Id, TransactionStatus.Unauthorized);

            TransactionStatus newdTransactionType = this.transaction.Status;

            Assert.AreNotEqual(oldTransactionType, newdTransactionType);
        }

        [Test]
        public void ChangeTransactionStatusShouldthrowArgumentExceptionTransactionDoesntExist()
        {
            this.allTransactions.Add(this.transaction);

            Assert.Throws<ArgumentException>(() => this.allTransactions.ChangeTransactionStatus(96, TransactionStatus.Failed));
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnAllTransactionIntheGivenRange()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Veni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            List<ITransaction> actual = this.allTransactions.GetAllInAmountRange(50, 150).ToList();
            List<ITransaction> expected =
                                new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction, this.transaction };

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollection()
        {
            Assert.AreEqual(0, this.allTransactions.GetAllInAmountRange(0, 150).Count());
        }

        [Test]
        public void RemoveTransactionByIdShouldRemovecorectly()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(this.transaction);

            this.allTransactions.RemoveTransactionById(Id);

            Assert.IsFalse(this.allTransactions.Contains(Id));
            Assert.AreEqual(1, this.allTransactions.Count);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.RemoveTransactionById(Id);
            });
        }

        [Test]
        public void GetByIdShouldReturnGivenTransactionId()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(this.transaction);

            ITransaction actualTransaction = this.allTransactions.GetById(Id);
            ITransaction expectedTransaction = this.transaction;

            Assert.AreEqual(expectedTransaction, actualTransaction);
        }

        [Test]
        public void GetByIdShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.allTransactions.GetById(Id));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnAllTransactionWithTheGivenStatus()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Veni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            ITransaction[] expectedTransaction = new ITransaction[3] { firstTransaction, secondTransaction, thirdTransaction };
            ITransaction[] actualTransaction = this.allTransactions.GetByTransactionStatus(TransactionStatus.Aborted).ToArray();

            Assert.AreEqual(expectedTransaction.Length, actualTransaction.Length);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetByTransactionStatus(TransactionStatus.Failed);
            });
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnAllSendersWithTheGivenStatus()
        {
            CreateNeTransaction();

            List<string> actualCount = this.allTransactions.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted).ToList();

            int expectedCount = 3;
            Assert.AreEqual(expectedCount, actualCount.Count);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowInvalidOperationException()
        {
            CreateNeTransaction();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);
            });
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnAllReceiversWithTheGivenStatus()
        {
            CreateNeTransaction();

            List<string> actualCount = this.allTransactions.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted).ToList();

            int expectedCount = 3;
            Assert.AreEqual(expectedCount, actualCount.Count);
        }

        [Test]
        public void GetAllRecieversWithTransactionStatusShouldThrowInvalidOperationException()
        {
            CreateNeTransaction();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            });
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldSortCorrectly()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Veni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);

            List<ITransaction> expected = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };
            expected = expected.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            List<ITransaction> actual = this.allTransactions.GetAllOrderedByAmountDescendingThenById().ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnCorrectly()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Jiji", "Veni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Jiji", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            List<ITransaction> expectedTransactions = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };
            expectedTransactions = expectedTransactions
                                                 .Where(x => x.From == "Jiji")
                                                 .OrderByDescending(x => x.Amount)
                                                 .ToList();

            List<ITransaction> actualTransactions = this.allTransactions.GetBySenderOrderedByAmountDescending("Jiji").ToList();

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetBySenderOrderedByAmountDescending("Benni");
            });
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnCollectionOfGivenReciversWithThathAmountRange()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Didi", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Didi", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            List<ITransaction> expected = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };
            List<ITransaction> actual = this.allTransactions.GetByReceiverAndAmountRange("Didi", 50, 150).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowInvalidOperationExeption()
        {
            CreateNeTransaction();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetByReceiverAndAmountRange("Anzhela", 50, 100);
            });
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnCollectionOfGivenReciversWithThathAmountRange()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Didi", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Didi", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            List<ITransaction> expected = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };
            List<ITransaction> actual = this.allTransactions.GetByReceiverOrderedByAmountThenById("Didi").ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowInvalidOperationExeption()
        {
            CreateNeTransaction();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetByReceiverOrderedByAmountThenById("Anzhela");
            });
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingdShouldReturnCollectionOfGivenSendersWithSortedAmount()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Didi", "Jeni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Jeni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Didi", "Anna", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            List<ITransaction> expected = new List<ITransaction>() { thirdTransaction, secondTransaction, firstTransaction };

            List<ITransaction> actual = this.allTransactions.GetBySenderAndMinimumAmountDescending("Didi", 30).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingdShouldThrowInavlidOperationExeption()
        {
            CreateNeTransaction();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.allTransactions.GetBySenderAndMinimumAmountDescending("Anhela", 30);
            });
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnCorrectlyTransactionsWithGivenStatusAndamount()
        {

            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Didi", "Jeni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Jeni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Didi", "Anna", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);

            List<ITransaction> expected = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };

            List<ITransaction> actual = this.allTransactions.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 150).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollection()
        {
            CreateNeTransaction();

            List<ITransaction> transactions =
                 this.allTransactions.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 50).ToList();

            Assert.AreEqual(0, transactions.Count);
        }

        [Test]
        public void GetEnumeratorSholdReturnCorrectly()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Aborted, "Jiji", "Beni", 50);
            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Aborted, "Didi", "Veni", 120);
            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);

            List<ITransaction> expected = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };

            IEnumerator<ITransaction> actual = this.allTransactions.GetEnumerator();

            int index = 0;

            while (actual.MoveNext())
            {

                ITransaction currentTransaction = actual.Current;
                Assert.AreEqual(expected[index++].Id, currentTransaction.Id);
            }

        }

        private void CreateNeTransaction()
        {
            ITransaction firstTransaction = new Transaction(96, TransactionStatus.Aborted, "Jiji", "Beni", 50);
            ITransaction secondTransaction = new Transaction(93, TransactionStatus.Aborted, "Didi", "Veni", 120);
            ITransaction thirdTransaction = new Transaction(89, TransactionStatus.Aborted, "Pepi", "Didi", 150);

            this.allTransactions.Add(firstTransaction);
            this.allTransactions.Add(secondTransaction);
            this.allTransactions.Add(thirdTransaction);
            this.allTransactions.Add(this.transaction);
        }
    }
}
