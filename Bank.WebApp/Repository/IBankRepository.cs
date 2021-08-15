using Bank.WebApp.Models;
using System.Collections.Generic;

namespace Bank.WebApp.Repository
{
    public interface IBankRepository
    {
        List<Transaction> GetTransactions();
        void Deposit(Transaction transaction);
        void Withdraw(Transaction transaction);
    }
}
