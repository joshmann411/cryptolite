using cryptolte.Interfaces;
using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> CreateAccount(Account account)
        {
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
            return new JsonResult("Account added successfully");
        }

        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            Account account = await _context.accounts.FindAsync(accountId);

            if (account != null)
            {
                _context.Remove(account);
                await _context.SaveChangesAsync();
            }

            return new JsonResult("BIlling deleted successfully !");
        }

        public async Task<Account> GetAccount(int accountId)
        {
            return await _context.accounts.FindAsync(accountId);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsOfClient(int clientId)
        {
            //_logger.LogInformation("Attempting to retrieve list of accounts of client");

            return await _context.accounts.Where(x => x. clientId == clientId).OrderBy(x => x.clientId).ToListAsync();
        }

        public async Task<IActionResult> UpdateAccount(Account accountChanges)
        {
            var tm = _context.accounts.Attach(accountChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return new JsonResult("Updated Successfully!");
        }
    }
}
