using cryptolte.Interfaces;
using cryptolte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Repositories.SqlRepo
{
    public class SqlContactRepository : IContact
    {
        private readonly AppDbContext _context;

        public SqlContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public string DeleteContact(int contactId)
        {
            //_logger.LogInformation("Deleting team detail of ID: " + softwareId);

            Contact contact = _context.contacts.Find(contactId);

            if (contact != null)
            {
                _context.Remove(contact);
                _context.SaveChanges();
            }

            return "Contact deleted successfully !";
        }

        public Contact GetContact(int contactId)
        {
            //_logger.LogInformation("Attempting to get contact");
            return _context.contacts.Find(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            //_logger.LogInformation("Attempting to get contacts");
            return _context.contacts;
        }

        public string UpdateContact(Contact contactChanges)
        {
            //_logger.LogInformation("Attempting to update contact changes");

            var tm = _context.contacts.Attach(contactChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully!";
        }
    }
}
