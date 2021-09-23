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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResetController : Controller
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly ILogger<ResetController> _logger;

        public ResetController(IBalanceRepository balanceRepository, ILogger<ResetController> logger)
        {
            _balanceRepository = balanceRepository;
            this._logger = logger;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Post()
        {
            _logger.LogInformation(SharedResource.ResetMessage);
            _balanceRepository.Dispose();
           return Ok("OK");
        }
    }
}
