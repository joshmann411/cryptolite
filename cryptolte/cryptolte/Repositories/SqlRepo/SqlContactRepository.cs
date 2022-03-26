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
    public class SqlContactRepository : IContact
    {
        private readonly AppDbContext _context;

        public SqlContactRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();
            return new JsonResult("Contact added successfully");
        }


        public async Task<IActionResult> DeleteContact(int contactId)
        {
            //_logger.LogInformation("Deleting team detail of ID: " + softwareId);

            Contact contact = await _context.contacts.FindAsync(contactId);

            if (contact != null)
            {
                _context.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return new JsonResult("Contact deleted successfully !");
        }

        public async Task<Contact> GetContact(int contactId)
        {
            //_logger.LogInformation("Attempting to get contact");
            return await _context.contacts.FindAsync(contactId);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            //_logger.LogInformation("Attempting to get contacts");
            return await _context.contacts.ToListAsync();
        }

        public async Task<IActionResult> UpdateContact(Contact contactChanges)
        {
            //_logger.LogInformation("Attempting to update contact changes");

            var tm = _context.contacts.Attach(contactChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return new JsonResult("Updated Successfully!");
        }
    }
}
