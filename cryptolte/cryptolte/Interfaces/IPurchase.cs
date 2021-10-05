using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IPurchase
    {
        IEnumerable<Purchase> GetPurchases();
        Purchase GetPurchase(int Id);
        string CreatePurchase(Purchase prchase);
        string UpdatePurchase(Purchase purchaseChanges); //only admins can update this
        string DeletePurchase(int purchaseId);
    }
}
