using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Response;
using BankDomain.Entities;
using System.Text.Json;

namespace BankApplication.AccountCommands
{
    public class DepositCommand : Command
    {
        //# Create account with initial balance
        //POST /event {"type":"deposit", "destination":"100", "amount":10}
        //201 {"destination": {"id":"100", "balance":10}}
        public override void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            var result = new CommandResponse()
            {
                Deposit = new DepositResponse()
                {
                    destination = new Destination()
                    {
                        id = 1,
                        balance = 10
                    }
                }
            };

            this.Result = result.Deposit;
        }
    }
}
