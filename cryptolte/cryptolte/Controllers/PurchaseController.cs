using cryptolte.Interfaces;
using cryptolte.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace cryptolte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchase _purchaseRepo;
        private readonly ILogger _logger;

        public PurchaseController(IPurchase purchaseRepo,
                                    ILoggerFactory loggerFactory)
        {
            _purchaseRepo = purchaseRepo;
            _logger = loggerFactory.CreateLogger(typeof(PurchaseController));
        }

        
        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known clients");

                IEnumerable<Purchase> purchases = _purchaseRepo.GetPurchases();

                _logger.LogInformation("clients list retrieved");

                return new JsonResult(purchases);
            }
            catch(Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving purchases list: {ex.Message}");

                return new JsonResult("Error retrieving purchases list", ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving purchase with ID: {id}");

                Purchase purchase = _purchaseRepo.GetPurchase(id);

                _logger.LogInformation($"Retrieving purchase with ID: {id}");

                return new JsonResult(purchase);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving purchase with ID: {id}. Exception: {ex.Message}");

                // throw 
                return new JsonResult("Error retrieving purchase with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        [Route("Post/{purchase}")]
        public JsonResult Post([FromBody] Purchase purchase)
        {
            try
            {
                _logger.LogInformation($"Adding new purchase with id: {purchase.Id}");

                string msg = _purchaseRepo.CreatePurchase(purchase);;

                _logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                _logger.LogError($"Error while attempting to add new purchase with id {purchase.Id}. Error {ex.Message}");

                return new JsonResult("Error occurred while adding new purchase", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Purchase purchaseChanges)
        {
            try
            {
                _logger.LogInformation($"Updating transaction changes. Object: {new JsonResult(purchaseChanges)}");

                string response = _purchaseRepo.UpdatePurchase(purchaseChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update purchase details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating purchase" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{purchaseId}")]
        public JsonResult Delete(int purchaseId)
        {
            try
            {
                _logger.LogInformation($"Deleting purchase with ID: {purchaseId}");

                string response = _purchaseRepo.DeletePurchase(purchaseId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete client with id {purchaseId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting client", ex.Message.ToString());
            }
        }
    }
}
