using BankApi.Dtos.Request;
using BankApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _accountInvoker.SetCommand(new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Type = account_event.Type,
                Balance = account_event.Amount,
                Destination = account_event.Destination
            });

            _accountInvoker.ExecuteCommand();

            return Ok(_accountInvoker.GetResult());
        }
    }
}
