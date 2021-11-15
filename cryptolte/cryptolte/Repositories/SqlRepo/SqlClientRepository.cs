using cryptolte.Interfaces;
using cryptolte.Models;
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

        public string AddClient(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
            return "Client added successfully";
        }

        public Client GetClient(int id)
        {
            //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);
            return _context.clients.Find(id);
        }

        public Client GetClientByEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Client client = GetClients().Where(x => x.email == email).FirstOrDefault();

                return client;
            }

            return null;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.clients;
        }

        public string RemoveClient(int id)
        {
            Client client = _context.clients.Find(id);

            if (client != null)
            {
                _context.Remove(client);
                _context.SaveChanges();
            }

            return "Client deleted Successfully !";
        }

        public string UpdateClient(Client clientChanges)
        {
            var tm = _context.clients.Attach(clientChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            _context.Dispose();

            return "Updated Successfully !";
        }
    }
}
