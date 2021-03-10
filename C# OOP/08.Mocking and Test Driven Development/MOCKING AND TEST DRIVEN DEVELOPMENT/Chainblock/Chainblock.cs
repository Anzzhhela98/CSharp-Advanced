using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> allTransaction;
        public Chainblock()
        {
            this.allTransaction = new Dictionary<int, ITransaction>();
        }
        public int Count => this.allTransaction.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new ArgumentException("Transaction already exists!");
            }

            this.allTransaction.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Transaction with this {id} doesnt't exist!");
            }

            this.allTransaction[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (this.allTransaction.ContainsKey(tx.Id))
            {
                return true;
            }

            return false;
        }

        public bool Contains(int id)
        {
            if (this.allTransaction.ContainsKey(id))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.allTransaction.Values.Where(x => x.Amount >= lo && x.Amount <= hi);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            string[] senders = this.allTransaction.Values.Where(tr => tr.Status == status)
                                                       .OrderBy(tr => tr.Amount)
                                                       .Select(s => s.To)
                                                       .ToArray();
            if (!senders.Any())
            {
                throw new InvalidOperationException("No such senders!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with this {id} doesnt't exist!");
            }
            return this.allTransaction[id];
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            string[] senders = this.allTransaction.Values.Where(tr => tr.Status == status)
                                                       .OrderBy(tr => tr.Amount)
                                                       .Select(s => s.From)
                                                       .ToArray();
            if (!senders.Any())
            {
                throw new InvalidOperationException("No such senders!");
            }

            return senders;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            ITransaction[] transactions = this.allTransaction.Values
                                        .Where(x => x.Status == status)
                                        .OrderByDescending(a => a.Amount).ToArray();

            if (!transactions.Any())
            {
                throw new InvalidOperationException("No such transactions!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.allTransaction.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> transactions = this.allTransaction.Values
                                             .Where(x => x.From == sender)
                                             .OrderByDescending(x => x.Amount)
                                             .ToList();

            if (!transactions.Any())
            {
                throw new InvalidOperationException($"The {sender} sender doesn't exist");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with this {id} doesn't exist!");
            }

            this.allTransaction.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
