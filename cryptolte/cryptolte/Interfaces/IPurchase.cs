using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IPurchase
    {
        Task<IEnumerable<Purchase>> GetPurchases();
        Task<Purchase> GetPurchase(int Id);
        Task<IActionResult> CreatePurchase(Purchase prchase);
        Task<IActionResult> UpdatePurchase(Purchase purchaseChanges); //only admins can update this
        Task<IActionResult> DeletePurchase(int purchaseId);
    }
}
