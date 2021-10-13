using cryptolte.Interfaces;
using cryptolte.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact _contactRepo;
        private readonly ILogger _logger;

        public ContactController(IContact contactRepo,
                                    ILoggerFactory loggerFactory)
        {
            _contactRepo = contactRepo;
            _logger = loggerFactory.CreateLogger(typeof(ContactController));
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known contacts");

                IEnumerable<Contact> contacts = _contactRepo.GetContacts();

                _logger.LogInformation("contacts list retrieved");

                return new JsonResult(contacts);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving contacts list: {ex.Message}");

                return new JsonResult("Error retrieving contacts list", ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving contacts with ID: {id}");

                Contact contact = _contactRepo.GetContact(id);

                _logger.LogInformation($"Retrieving contacts with ID: {id}");

                return new JsonResult(contact);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving contact with ID: {id}. Exception: {ex.Message}");

                // throw 
                return new JsonResult("Error retrieving contact with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        //[Route("Post/{contact}")]
        public JsonResult Post([FromBody] Contact contact)
        {
            try
            {
                _logger.LogInformation($"Adding new contact with id: {contact.ContactId}");

                string msg = _contactRepo.CreateContact(contact);

                _logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                _logger.LogError($"Error while attempting to add new contact with id {contact.ContactId}. Error {ex.Message}");

                return new JsonResult("Error occurred while adding new contact", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Contact contactChanges)
        {
            try
            {
                _logger.LogInformation($"Updating contact changes. Object: {new JsonResult(contactChanges)}");

                string response = _contactRepo.UpdateContact(contactChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update contact details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating contact" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{contactId}")]
        public JsonResult Delete(int contactId)
        {
            try
            {
                _logger.LogInformation($"Deleting contactId with ID: {contactId}");

                string response = _contactRepo.DeleteContact(contactId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete contact with id {contactId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting contact", ex.Message.ToString());
            }
        }
    }
}
