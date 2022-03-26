using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IBilling
    {
        Task<IEnumerable<Billing>> GetBillings();
        Task<Billing> GetBilling(int billingId);
        Task<IActionResult> CreateBilling(Billing billing);
        Task<IActionResult> UpdateBilling(Billing billingChanges);
        Task<IActionResult> DeleteBilling(int billingId);
    }
}
