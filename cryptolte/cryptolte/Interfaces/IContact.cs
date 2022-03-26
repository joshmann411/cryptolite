using cryptolte.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IContact
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(int contactId);
        Task<IActionResult> CreateContact(Contact contact);
        Task<IActionResult> UpdateContact(Contact contactChanges);
        Task<IActionResult> DeleteContact(int contactId);
    }
}
