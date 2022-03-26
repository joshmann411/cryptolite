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
    public class SqlBillingRepository : IBilling
    {
        private readonly AppDbContext _context;

        public SqlBillingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateBilling(Billing billing)
        {
            await _context.AddAsync(billing);
            await _context.SaveChangesAsync();
            return new JsonResult("Billing added successfully");
        }

        public async Task<IActionResult> DeleteBilling(int billingId)
        {
            Billing billing = await _context.billings.FindAsync(billingId);

            if (billing != null)
            {
                _context.Remove(billing);
                await _context.SaveChangesAsync();
            }

            return new JsonResult("BIlling deleted successfully !");
        }

        public async Task<Billing> GetBilling(int billingId)
        {
            return await _context.billings.FindAsync(billingId);
        }

        public async Task<IEnumerable<Billing>> GetBillings()
        {
            return await _context.billings.ToListAsync();
        }

        public async Task<IActionResult> UpdateBilling(Billing billingChanges)
        {
            var tm = _context.billings.Attach(billingChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return new JsonResult("Updated Successfully!");
        }
    }
}
