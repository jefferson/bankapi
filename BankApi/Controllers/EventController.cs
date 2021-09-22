using BankApi.Dtos;
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
    public class EventController : Controller
    {
        private readonly IAccountInvoker _accountInvoker;

        public EventController(IAccountInvoker accountInvoker)
        {
            _accountInvoker = accountInvoker;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Post(EventDto account_event)
        {
            _accountInvoker.SetCommand(new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Type = account_event.Type
            });

            _accountInvoker.ExecuteCommand();

            return Ok("OK");
        }
    }
}
