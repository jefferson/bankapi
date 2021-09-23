using BankApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
 
namespace BankApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }


        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(decimal))]
        public IActionResult Get([FromQuery(Name = "account_id")] string account_id)
        {
            try
            {
                return Ok(_balanceRepository.Get(account_id).balance_value);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(0);
            }
        }

    }
}
