using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class TransactionContext : DbContext
    {

        public TransactionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                TransactionId = 1,
                Value = 5.40f,
                DateAndTime = DateTime.Now,
                AccountNumber = 39874634
            }, new Transaction
            {
                TransactionId = 2,
                Value = 1.76f,
                DateAndTime = DateTime.Now,
                AccountNumber = 82736454
            });
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
