using cryptolte.Interfaces;
using cryptolte.Models;
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
    public class AccountTypeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAccountType _accountType;

        public AccountTypeController(ILoggerFactory loggerFactory,
                                        IAccountType accountType)
        {
            _logger = loggerFactory.CreateLogger(typeof(BillingController));
            _accountType = accountType;
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known accounts types");

                IEnumerable<AccountType> accounts = _accountType.GetAccTypes();

                _logger.LogInformation("List of account types retrieved");

                return new JsonResult(accounts);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving account types: {ex.Message}");

                return new JsonResult("Error retrieving account types", ex.Message.ToString());
            }
        }

        //get account(s) for a specfic user (userId) or email 

        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving account type with ID: {id}");

                AccountType accountType = _accountType.GetAccountType(id);

                _logger.LogInformation($"Retrieving account type with ID: {id}");

                return new JsonResult(accountType);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving account type with ID: {id}. Exception: {ex.Message}");

                // throw 
                return new JsonResult("Error retrieving account type with ID " + id, ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("Post")]
        //[Route("Post/{contact}")]
        public JsonResult Post([FromBody] AccountType accountType)
        {
            try
            {
                _logger.LogInformation($"Adding new account type");

                string msg = _accountType.CreateNewAccType(accountType);

                _logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                _logger.LogError($"Error while attempting to add new account type. Error {ex.Message}");

                return new JsonResult("Error occurred while adding new account type", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] AccountType accountTypeChanges)
        {
            try
            {
                _logger.LogInformation($"Updating account changes. Object: {new JsonResult(accountTypeChanges)}");

                string response = _accountType.UpdateAccountTye(accountTypeChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update account type details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating account type" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{accountId}")]
        public JsonResult Delete(int accountTypeId)
        {
            try
            {
                _logger.LogInformation($"Deleting accountTypeId with ID: {accountTypeId}");

                string response = _accountType.DeleteAccountType(accountTypeId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete account type with id {accountTypeId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting account type", ex.Message.ToString());
            }
        }
    }
}
