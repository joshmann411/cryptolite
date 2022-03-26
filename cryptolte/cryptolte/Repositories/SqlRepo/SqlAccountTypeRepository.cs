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
    public class SqlAccountTypeRepository : IAccountType
    {
        private readonly AppDbContext _context;

        public SqlAccountTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateNewAccType(AccountType accountType)
        {
            await _context.AddAsync(accountType);
            await _context.SaveChangesAsync();
            return new JsonResult("Account type added successfully");
        }

        public async Task<IActionResult> DeleteAccountType(int billingId)
        {
            AccountType accountType = await _context.accountType.FindAsync(billingId);

            if (accountType != null)
            {
                _context.Remove(accountType);
                await _context.SaveChangesAsync();
            }

            return new JsonResult("Account type deleted successfully !");
        }

        public async Task<AccountType> GetAccountType(int accTypeId)
        {
            return await _context.accountType.FindAsync(accTypeId);
        }

        public async Task<IEnumerable<AccountType>> GetAccTypes()
        {
            return await _context.accountType.ToListAsync();
        }

        public async Task<IActionResult> UpdateAccountTye(AccountType accTypeChanges)
        {
            var tm = _context.accountType.Attach(accTypeChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return new JsonResult("Updated Successfully!");
        }
    }
}
