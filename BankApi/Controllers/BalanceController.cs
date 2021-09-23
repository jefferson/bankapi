using BankApplication.Interface;
using BankApplication.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BankApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly ILogger<BalanceController> _logger;

        public BalanceController(IBalanceRepository balanceRepository, ILogger<BalanceController> logger)
        {
            _balanceRepository = balanceRepository;
            this._logger = logger;
        }


        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(decimal))]
        public IActionResult Get([FromQuery(Name = "account_id")] string account_id)
        {
            try
            {
                _logger.LogInformation(SharedResource.BalanceEventCalled, account_id);

                return Ok(_balanceRepository.Get(account_id).balance_value);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(0);
            }
        }

    }
}
