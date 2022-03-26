using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IAccount
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(int accountId);
        Task<IActionResult> CreateAccount(Account account);
        Task<IActionResult> UpdateAccount(Account accountChanges);
        Task<IActionResult> DeleteAccount(int accountId);
        Task<IEnumerable<Account>> GetAccountsOfClient(int clientId);
    }
}
