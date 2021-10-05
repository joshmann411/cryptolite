using cryptolte.Interfaces;
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


    }
}
