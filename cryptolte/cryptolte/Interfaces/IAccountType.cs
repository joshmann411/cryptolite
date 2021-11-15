using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IAccountType
    {
        IEnumerable<AccountType> GetAccTypes();
        AccountType GetAccountType(int accTypeId);
        string CreateNewAccType(AccountType accountType);
        string UpdateAccountTye(AccountType accTypeChanges);
        string DeleteAccountType(int billingId);
    }
}
