using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ResetController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Post()
        {
            _balanceRepository.Dispose();
           return Ok("OK");
        }
    }
}
