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
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known billings");

                IEnumerable<Billing> billings = _billingRepo.GetBillings();

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
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving billing with ID: {id}");

                Billing billing = _billingRepo.GetBilling(id);

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

        [HttpPost]
        [Route("Post")]
        //[Route("Post/{contact}")]
        public JsonResult Post([FromBody] Billing billing)
        {
            try
            {
                _logger.LogInformation($"Adding new billing with id: {billing.BillingId}");

                string msg = _billingRepo.CreateBilling(billing);

                _logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                _logger.LogError($"Error while attempting to add new billing with id {billing.BillingId}. Error {ex.Message}");

                return new JsonResult("Error occurred while adding new billing", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Billing billingChanges)
        {
            try
            {
                _logger.LogInformation($"Updating billing changes. Object: {new JsonResult(billingChanges)}");

                string response = _billingRepo.UpdateBilling(billingChanges);

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
        public JsonResult Delete(int billingId)
        {
            try
            {
                _logger.LogInformation($"Deleting billingId with ID: {billingId}");

                string response = _billingRepo.DeleteBilling(billingId);

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
