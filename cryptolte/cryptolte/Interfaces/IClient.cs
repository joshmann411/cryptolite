using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IClient
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        string AddClient(Client client);
        string UpdateClient(Client clientChanges);
        string RemoveClient(int id);
        Client GetClientByEmail(string email);
    }
}
