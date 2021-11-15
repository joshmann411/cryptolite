using cryptolte.Interfaces;
using cryptolte.Models;
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

        public string CreateNewAccType(AccountType accountType)
        {
            _context.Add(accountType);
            _context.SaveChanges();
            return "Account type added successfully";
        }

        public string DeleteAccountType(int billingId)
        {
            AccountType accountType = _context.accountType.Find(billingId);

            if (accountType != null)
            {
                _context.Remove(accountType);
                _context.SaveChanges();
            }

            return "Account type deleted successfully !";
        }

        public AccountType GetAccountType(int accTypeId)
        {
            return _context.accountType.Find(accTypeId);
        }

        public IEnumerable<AccountType> GetAccTypes()
        {
            return _context.accountType;
        }

        public string UpdateAccountTye(AccountType accTypeChanges)
        {
            var tm = _context.accountType.Attach(accTypeChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully!";
        }
    }
}
