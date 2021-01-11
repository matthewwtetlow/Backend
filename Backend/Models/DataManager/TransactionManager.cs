using Backend.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DataManager
{
    public class TransactionManager : IDataRepository<Transaction>
    {
        readonly TransactionContext _transactionContext;
        public TransactionManager(TransactionContext context)
        {
            _transactionContext = context;
        }
        public IEnumerable<Transaction> GetAll()
        {
            return _transactionContext.Transactions.ToList();
        }
        public Transaction Get(long id)
        {
            return _transactionContext.Transactions
                  .FirstOrDefault(e => e.TransactionId == id);
        }
        public void Add(Transaction entity)
        {
            _transactionContext.Transactions.Add(entity);
            _transactionContext.SaveChanges();
        }
        public void Update(Transaction transaction, Transaction entity)
        {
            transaction.Value = entity.Value;
            transaction.DateAndTime = entity.DateAndTime;
            transaction.AccountNumber = entity.AccountNumber;
          
            _transactionContext.SaveChanges();
        }
        public void Delete(Transaction transaction)
        {
            _transactionContext.Transactions.Remove(transaction);
            _transactionContext.SaveChanges();
        }
    }
}
