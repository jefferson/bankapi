using BankApi.Dtos.Request;
using BankApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BankApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IAccountInvoker _accountInvoker;
        private readonly ILogger<EventController> _logger;

        public EventController(IAccountInvoker accountInvoker, ILogger<EventController> logger)
        {
            _accountInvoker = accountInvoker;
            this._logger = logger;
        }

        [HttpPost()]
        public IActionResult Post(EventRequest account_event)
        {            
            try
            {
                _logger.LogInformation("Action called: type: {0}, Origin: {1}, Destination: {2}", account_event.Type, account_event.Origin, account_event.Destination);

                _accountInvoker.SetCommand(new BankApplication.AccountCommands.Helper.AccountEvent()
                {
                    Type = account_event.Type,
                    Amount = account_event.Amount,
                    Destination = account_event.Destination,
                    Origin = account_event.Origin
                });

                _accountInvoker.ExecuteCommand();

                return StatusCode( StatusCodes.Status201Created, _accountInvoker.GetResult());
            }
            catch (KeyNotFoundException e)
            {
                _logger.LogInformation("KeyNotFound for action: type: {0}, Origin: {1}, Destination: {2}", account_event.Type, account_event.Origin, account_event.Destination);

                return NotFound(0);
            }
        }
    }
}
