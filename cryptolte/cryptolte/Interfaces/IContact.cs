using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IContact
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int contactId);
        string CreateContact(Contact contact);
        string UpdateContact(Contact contactChanges);
        string DeleteContact(int contactId);
    }
}
