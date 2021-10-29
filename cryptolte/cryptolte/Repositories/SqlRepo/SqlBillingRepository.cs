using cryptolte.Interfaces;
using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Repositories.SqlRepo
{
    public class SqlBillingRepository : IBilling
    {
        private readonly AppDbContext _context;

        public SqlBillingRepository(AppDbContext context)
        {
            _context = context;
        }

        public string CreateBilling(Billing billing)
        {
            _context.Add(billing);
            _context.SaveChanges();
            return "Billing added successfully";
        }

        public string DeleteBilling(int billingId)
        {
            Billing billing = _context.billings.Find(billingId);

            if (billing != null)
            {
                _context.Remove(billing);
                _context.SaveChanges();
            }

            return "BIlling deleted successfully !";
        }

        public Billing GetBilling(int billingId)
        {
            return _context.billings.Find(billingId);
        }

        public IEnumerable<Billing> GetBillings()
        {
            return _context.billings;
        }

        public string UpdateBilling(Billing billingChanges)
        {
            var tm = _context.billings.Attach(billingChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully!";
        }
    }
}
