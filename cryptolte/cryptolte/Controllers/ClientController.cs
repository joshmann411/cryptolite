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
    public class ClientController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory loggerFactory;
        private readonly IClient _client;

        public ClientController(ILoggerFactory loggerFactory,
                                IClient client)
        {
            _logger = loggerFactory.CreateLogger(typeof(BillingController));
            this.loggerFactory = loggerFactory;
            _client = client;
        }


        [HttpGet]
        [Route("GetClientByEmail/{email}")]
        public JsonResult GetClientByEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                try
                {
                    _logger.LogInformation($"Retrieving client with email: {email}");

                    Client client = _client.GetClientByEmail(email);

                    _logger.LogInformation($"Client retrieved");

                    return new JsonResult(client);
                }
                catch (Exception ex)
                {
                    //log error
                    _logger.LogError($"Error while retrieving client with Email: {email}. Exception: {ex.Message}");

                    // throw 
                    return new JsonResult("Error retrieving client with Email " + email, ex.Message.ToString());
                }
            }

            //
            _logger.LogError($"No Email Provided in your request");

            return new JsonResult(BadRequest("Error occured with Email"));
        }
    
        [HttpPut]
        [Route("UpdateClientDetail")]
        public IActionResult UpdateClientDetail([FromBody] Client clientChanges)
        {
            try
            {
                _logger.LogInformation($"Updating client details {clientChanges.id}");

                string msg = _client.UpdateClient(clientChanges);

                _logger.LogInformation($"Client details of ID: {clientChanges.id} updated successfully");
                
                return new JsonResult(msg);
            }
            catch(Exception ex)
            {
                //log
                _logger.LogError($"Error occurred while updating client details. Details: {ex.Message}");

                //return
                return new JsonResult("Error occurred");
            }
        }
    }
}
