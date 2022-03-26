using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IClient
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<IActionResult> AddClient(Client client);
        Task<IActionResult> UpdateClient(Client clientChanges);
        Task<IActionResult> RemoveClient(int id);
        Task<Client> GetClientByEmail(string email);
    }              
}
