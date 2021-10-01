using BankApplication;
using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResetController : Controller
    {
        private readonly IResetService _resetService;
        private readonly ILogger<ResetController> _logger;

        public ResetController(IResetService resetService, ILogger<ResetController> logger)
        {
            this._resetService = resetService;
            this._logger = logger;
        }

        [HttpPost(), Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Post()
        {
            _logger.LogInformation(SharedResource.ResetMessage);
            _resetService.Dispose();
           return StatusCode(StatusCodes.Status200OK, "OK");
        }
    }
}
