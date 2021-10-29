using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IBilling
    {
        IEnumerable<Billing> GetBillings();
        Billing GetBilling(int billingId);
        string CreateBilling(Billing billing);
        string UpdateBilling(Billing billingChanges);
        string DeleteBilling(int billingId);
    }
}
