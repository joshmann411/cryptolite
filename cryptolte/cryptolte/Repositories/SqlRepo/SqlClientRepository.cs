using cryptolte.Interfaces;
using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Repositories.SqlRepo
{
    public class SqlClientRepository : IClient
    {
        private readonly AppDbContext _context;

        public SqlClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddClient(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
            return new JsonResult("Client added successfully");
        }

        public async Task<Client> GetClient(int id)
        {
            //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);
            return await _context.clients.FindAsync(id);
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                IEnumerable<Client> clients = await GetClients();

                Client client = clients.Where(x => x.email == email).FirstOrDefault();

                return client;
            }

            return null;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.clients.ToListAsync();
        }

        public async Task<IActionResult> RemoveClient(int id)
        {
            Client client = await _context.clients.FindAsync(id);

            if (client != null)
            {
                _context.Remove(client);
                await _context.SaveChangesAsync();
            }

            return new JsonResult("Client deleted Successfully !");
        }

        public async Task<IActionResult> UpdateClient(Client clientChanges)
        {
            var tm = _context.clients.Attach(clientChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Dispose();

            return new JsonResult("Updated Successfully !");
        }
    }
}
