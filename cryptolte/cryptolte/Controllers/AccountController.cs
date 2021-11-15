using cryptolte.Interfaces;
using cryptolte.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory loggerFactory;

        //private readonly ILoggerFactory loggerFactory;
        private readonly IAccount _accountRepo;
        private readonly IConfiguration _configuration;
        private readonly IClient _clientRepo;

        public AccountController(ILoggerFactory loggerFactory,
                                IAccount accountRepo,
                                IConfiguration configuration,
                                IClient clientRepo)
        {
            _logger = loggerFactory.CreateLogger(typeof(BillingController));
            this.loggerFactory = loggerFactory;
            //this.loggerFactory = loggerFactory;
            _accountRepo = accountRepo;
            _configuration = configuration;
            _clientRepo = clientRepo;
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known accounts");

                IEnumerable<Account> accounts = _accountRepo.GetAccounts();

                _logger.LogInformation("Accounts list retrieved");

                return new JsonResult(accounts);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving accounts list: {ex.Message}");

                return new JsonResult("Error retrieving accounts list", ex.Message.ToString());
            }
        }

        //get account(s) for a specfic user (userId) or email 

        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving account with ID: {id}");

                Account account = _accountRepo.GetAccount(id);

                _logger.LogInformation($"Retrieving account with ID: {id}");

                return new JsonResult(account);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving account with ID: {id}. Exception: {ex.Message}");

                // throw 
                return new JsonResult("Error retrieving account with ID " + id, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("getAccountsOfClientByEmail/{clientEmail}")]
        public JsonResult getAccountsOfClientByEmail(string clientEmail) //get by Email
        {
            try
            {
                if (!string.IsNullOrEmpty(clientEmail) && !clientEmail.Contains("null"))
                {
                    _logger.LogInformation("==> Retrieving accounts with client email: {0}", clientEmail);

                    //get client object
                    Client cl = _clientRepo.GetClients().Where(x => x.email == clientEmail).FirstOrDefault();

                    if(cl != null)
                    {
                        IEnumerable<Account> accounts = _accountRepo.GetAccountsOfClient(cl.id);

                        _logger.LogInformation("<== Retrieving accounts with client email: {0}:", clientEmail);

                        return new JsonResult(accounts);
                    }

                    return new JsonResult("Errpr occurred with Client");
                }
                else
                {
                    _logger.LogInformation("<== Empty email provided");

                    return new JsonResult(new Exception("Empty email provided"));
                }
            }
            catch (Exception ex)
            {
                // log error
                _logger.LogError("XXX Error while retrieving business with email: {0} | Exception: {1}", clientEmail, ex.Message.ToString());

                // throw 
                return new JsonResult("Error retrieving accounts of client Email " + clientEmail, ex.Message.ToString());

            }
        }


        [HttpPost]
        [Route("Post")]
        //[Route("Post/{contact}")]
        public JsonResult Post([FromBody] Account account)
        {
            if(account != null)
            {
                //remove everything after type
                int indx = account.accType.IndexOf('-');

                account.accType = account.accType.Remove(indx).Trim();

                //default confirmation to false
                account.confirmed = false;

                //get defaulted wallet from appsettings
                account.wallet = _configuration.GetSection("WalletAddress").Value;

                try
                {
                    _logger.LogInformation($"Adding new account with id: {account.AccoutId }");

                    string msg = _accountRepo.CreateAccount(account);

                    _logger.LogInformation("Added Successfully !");

                    return new JsonResult(msg + "|" +account.wallet);
                }
                catch (Exception ex)
                {
                    //log 
                    _logger.LogError($"Error while attempting to add new account with id {account.AccoutId}. Error {ex.Message}");

                    return new JsonResult("Error occurred while adding new account", ex.Message.ToString());
                }
            }

            return new JsonResult(BadRequest("Error occurred"));
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Account accountChanges)
        {
            try
            {
                _logger.LogInformation($"Updating account changes. Object: {new JsonResult(accountChanges)}");

                string response = _accountRepo.UpdateAccount(accountChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update account details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating account" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{accountId}")]
        public JsonResult Delete(int accountId)
        {
            try
            {
                _logger.LogInformation($"Deleting accountId with ID: {accountId}");

                string response = _accountRepo.DeleteAccount(accountId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete account with id {accountId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting account", ex.Message.ToString());
            }
        }
    }
}
