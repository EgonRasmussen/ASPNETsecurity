using Bank.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bank.WebApp.Repository
{
    public class BankRepository : IBankRepository
    {
        private List<Transaction> transactions;

        public BankRepository()
        {
            transactions = new List<Transaction> { new Transaction { Amount = 1000, Balance = 1000, From = "Me", To = "Me" } };
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

        public void Deposit(Transaction transaction)
        {
            transaction.Balance = transactions.Sum(t => t.Amount);
            transaction.Balance += transaction.Amount;
            transaction.To = "Me";
            transactions.Add(transaction);
        }

        public void Withdraw(Transaction transaction)
        {
            transaction.Balance = transactions.Sum(t => t.Amount);
            transaction.Balance -= transaction.Amount;
            transaction.From = "Me";
            transactions.Add(transaction);
        }
    }
}
