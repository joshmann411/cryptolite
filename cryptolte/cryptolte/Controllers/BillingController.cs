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
    public class BillingController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBilling _billingRepo;

        public BillingController(ILoggerFactory loggerFactory,
                                IBilling billingRepo)
        {
            _logger = loggerFactory.CreateLogger(typeof(BillingController));
            _billingRepo = billingRepo;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known billings");

                IEnumerable<Billing> billings = await _billingRepo.GetBillings();

                _logger.LogInformation("billings list retrieved");

                return new JsonResult(billings);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving billings list: {ex.Message}");

                return new JsonResult("Error retrieving billings list", ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving billing with ID: {id}");

                Billing billing = await _billingRepo.GetBilling(id);

                _logger.LogInformation($"Retrieving billing with ID: {id}");

                return new JsonResult(billing);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving billing with ID: {id}. Exception: {ex.Message}");

                // throw 
                return new JsonResult("Error retrieving billing with ID " + id, ex.Message.ToString());
            }
        }


        [HttpGet]
        [Route("GetBillingsLinkedToAccount/{clientId}")]
        public async Task<IActionResult> GetBillingsLinkedToAccount(string clientId)
        {
            try
            {
                //all billings
                IEnumerable<Billing> _billings = await _billingRepo.GetBillings();

                //billings for client of concern
                IEnumerable<Billing> billingsOfConcern = _billings.Where(x => x.LinkedAccount == clientId);

                return new JsonResult(billingsOfConcern);
            }
            catch(Exception ex)
            {
                //log error
                _logger.LogError($"Error occurred while getting billings that are linked to client: {clientId}");

                return new JsonResult("Error Occurred");
            
            }
        }

        [HttpPost]
        [Route("Post")]
        //[Route("Post/{contact}")]
        public async Task<IActionResult> Post([FromBody] Billing billing)
        {
            var msg = string.Empty;

            JsonResult jMsg = new JsonResult("");

            //get all billing linked to the client
            IEnumerable<Billing> billings = await _billingRepo.GetBillings();

            //accounts for a specific user
            IEnumerable<Billing> concernedBilling = billings.Where(x => x.LinkedAccount == billing.LinkedAccount);

            //count accounts linked to a specific user
            int cbCount = concernedBilling.Count();

            //if the user already have more than 1 account(s)
            if (cbCount > 0)
            {
                //see if there is any match on the card number that we already know of
                int countCardNumberThatMatchesIncomingOne = concernedBilling.Count(x => x.CCNumber == billing.CCNumber);
            
                //if it is more than 1
                //if the HOLDER NAME and CARD NUM. counts > 1 
                if(countCardNumberThatMatchesIncomingOne > 0) //there is at least 1 of that that we know of
                {
                    //then you can't add the same this
                    msg = "Card exists already"; 

                }
                else
                {
                    //we do not know about this card. Please add
                    jMsg = await AddCardBilling(billing);

                    //assign appr to msg
                    msg = jMsg.Value.ToString();
                }

                return new JsonResult(msg);
            }

            jMsg = await AddCardBilling(billing);

            //assign appr to msg
            msg = jMsg.Value.ToString();

            return new JsonResult(msg);

        }

        /// <summary>
        /// INTERNAL METHOD: not an endpoint
        /// </summary>
        /// <param name="_billing"></param>
        /// <returns></returns>
        internal async Task<JsonResult> AddCardBilling(Billing _billing)
        {
            try
            {
                _logger.LogInformation($"Adding new billing");

                var resp = await _billingRepo.CreateBilling(_billing);

                string msg = "Card Added Successfully";

                _logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                _logger.LogError($"Error while attempting to add new billing. Error {ex.Message}");

                return new JsonResult("Error occurred while adding new billing", ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBillingAddressOfAccount([FromBody] BillingAddressDataModel billingAddressDAO)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Billing billingChanges)
        {
            try
            {
                _logger.LogInformation($"Updating billing changes. Object: {new JsonResult(billingChanges)}");

                var response = await _billingRepo.UpdateBilling(billingChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update billing details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating billing" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{billingId}")]
        public async Task<IActionResult> Delete(int billingId)
        {
            try
            {
                _logger.LogInformation($"Deleting billingId with ID: {billingId}");

                var response = await _billingRepo.DeleteBilling(billingId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete billing with id {billingId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting billing", ex.Message.ToString());
            }
        }
    }
}
