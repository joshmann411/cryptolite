using cryptolte.Interfaces;
using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Repositories.SqlRepo
{
    public class SqlAccountRepository : IAccount
    {
        private readonly AppDbContext _context;

        public SqlAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public string CreateAccount(Account account)
        {
            _context.Add(account);
            _context.SaveChanges();
            return "Account added successfully";
        }

        public string DeleteAccount(int accountId)
        {
            Account account = _context.accounts.Find(accountId);

            if (account != null)
            {
                _context.Remove(account);
                _context.SaveChanges();
            }

            return "BIlling deleted successfully !";
        }

        public Account GetAccount(int accountId)
        {
            return _context.accounts.Find(accountId);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.accounts;
        }

        public IEnumerable<Account> GetAccountsOfClient(int clientId)
        {
            //_logger.LogInformation("Attempting to retrieve list of accounts of client");

            return _context.accounts.Where(x => x. clientId == clientId).OrderBy(x => x.clientId);
        }

        public string UpdateAccount(Account accountChanges)
        {
            var tm = _context.accounts.Attach(accountChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully!";
        }
    }
}
