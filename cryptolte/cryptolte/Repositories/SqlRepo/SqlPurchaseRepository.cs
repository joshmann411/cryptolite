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
    public class SqlPurchaseRepository : IPurchase
    {
        private readonly AppDbContext _context;

        public SqlPurchaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreatePurchase(Purchase purchase)
        {
            await _context.AddAsync(purchase);
            await _context.SaveChangesAsync();
            return new JsonResult("Purchase added successfully");
        }

        public async Task<IActionResult> DeletePurchase(int purchaseId)
        {
            //_logger.LogInformation("Deleting purchase of ID: " + purchaseId);

            Purchase purchase = await _context.purchases.FindAsync(purchaseId);

            if (purchase != null)
            {
                _context.Remove(purchase);
                await _context.SaveChangesAsync();
            }

            return new JsonResult("Purchase deleted successfully !");
        }

        public async Task<Purchase> GetPurchase(int Id)
        {
            //_logger.LogInformation("Attempting to retrieve purchase with ID: " + Id);

            return await _context.purchases.FindAsync(Id);
        }

        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            //_logger.LogInformation("Attempting to retrieve list of purchases");

            return await _context.purchases.ToListAsync();
        }

        public async Task<IActionResult> UpdatePurchase(Purchase purchaseChanges)
        {
            //_logger.LogInformation("Attempting to update purchase changes");

            var tm = _context.purchases.Attach(purchaseChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return new JsonResult("Updated Successfully !");
        }
    }
}
