using cryptolte.Interfaces;
using cryptolte.Models;
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

        public string CreatePurchase(Purchase purchase)
        {
            _context.Add(purchase);
            _context.SaveChanges();
            return "Purchase added successfully";
        }

        public string DeletePurchase(int purchaseId)
        {
            //_logger.LogInformation("Deleting purchase of ID: " + purchaseId);

            Purchase purchase = _context.purchases.Find(purchaseId);

            if (purchase != null)
            {
                _context.Remove(purchase);
                _context.SaveChanges();
            }

            return "Purchase deleted successfully !";
        }

        public Purchase GetPurchase(int Id)
        {
            //_logger.LogInformation("Attempting to retrieve purchase with ID: " + Id);

            return _context.purchases.Find(Id);
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            //_logger.LogInformation("Attempting to retrieve list of purchases");

            return _context.purchases;
        }

        public string UpdatePurchase(Purchase purchaseChanges)
        {
            //_logger.LogInformation("Attempting to update purchase changes");

            var tm = _context.purchases.Attach(purchaseChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully !";
        }
    }
}
