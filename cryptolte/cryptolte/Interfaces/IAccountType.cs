using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IAccountType
    {
        Task<IEnumerable<AccountType>> GetAccTypes();
        Task<AccountType> GetAccountType(int accTypeId);
        Task<IActionResult> CreateNewAccType(AccountType accountType);
        Task<IActionResult> UpdateAccountTye(AccountType accTypeChanges);
        Task<IActionResult> DeleteAccountType(int billingId);
    }
}
