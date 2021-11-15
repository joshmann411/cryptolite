using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IAccount
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int accountId);
        string CreateAccount(Account account);
        string UpdateAccount(Account accountChanges);
        string DeleteAccount(int accountId);
        IEnumerable<Account> GetAccountsOfClient(int clientId);
    }
}
