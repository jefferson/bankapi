using BankApi.Dtos.Request;
using BankApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Post(EventRequest account_event)
        {            
            try
            {
                _accountInvoker.SetCommand(new BankApplication.AccountCommands.Helper.AccountEvent()
                {
                    Type = account_event.Type,
                    Amount = account_event.Amount,
                    Destination = account_event.Destination,
                    Origin = account_event.Origin
                });

                _accountInvoker.ExecuteCommand();

                return Ok(_accountInvoker.GetResult());
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(0);
            }
        }
    }
}
