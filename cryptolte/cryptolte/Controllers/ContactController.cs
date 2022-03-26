using cryptolte.Interfaces;
using cryptolte.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known contacts");

                IEnumerable<Contact> contacts = await _contactRepo.GetContacts();

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
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving contacts with ID: {id}");

                Contact contact = await _contactRepo.GetContact(id);

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
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            try
            {
                _logger.LogInformation($"Adding new contact with id: {contact.ContactId}");

                var msg = await _contactRepo.CreateContact(contact);

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
        public async Task<IActionResult> Put([FromBody] Contact contactChanges)
        {
            try
            {
                _logger.LogInformation($"Updating contact changes. Object: {new JsonResult(contactChanges)}");

                var response = await _contactRepo.UpdateContact(contactChanges);

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
        public async Task<IActionResult> Delete(int contactId)
        {
            try
            {
                _logger.LogInformation($"Deleting contactId with ID: {contactId}");

                var response = await _contactRepo.DeleteContact(contactId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete contact with id {contactId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting contact", ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("WriteContactUsToFile")]
        public async Task<IActionResult> WriteContactUsToFile([FromBody] ContactUs contactUs)
        {
            if (contactUs != null)
            {
                try
                {
                    //write the details down to a new file
                    //string wrknDir = Directory.GetCurrentDirectory();

                    string contactPath = "C://ContactUs//";

                    // path does not exist
                    if (!Directory.Exists(contactPath))
                    {
                        //create it
                        Directory.CreateDirectory(contactPath);
                    }

                    string txt2Write = string.Format($"Name: {contactUs.Name} \n Email: {contactUs.Email} \n " +
                           $"Subject: {contactUs.Subject} \n Message: {contactUs.Message}");



                    string filePath = contactPath + contactUs.Name + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + ".txt";

                    //if file does not exist
                    if (!System.IO.File.Exists(filePath))
                    {
                        //create 
                        using(FileStream fs = System.IO.File.Create(filePath))
                        {
                            //System.IO.File.Create(filePath);
                            //write data so long
                            //await fs.WriteAsync(txt2Write);

                            using (var writer = new StreamWriter(fs))
                            {
                                await writer.WriteAsync(txt2Write);
                            }

                            return new JsonResult("Message received. We will be in touch with you");
                        }
                    }
                   
                    //just go ahead and write
                    var stream = new FileStream(filePath, FileMode.Open);

                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(txt2Write);
                    }

                    return new JsonResult("Message received. We will be in touch with you");

                }
                catch (Exception ex)
                {
                    string err = ex.Message.ToString();

                    return new JsonResult("Fatal Error");
                }
            }


            return new JsonResult("Data is null");
        }

    }
}