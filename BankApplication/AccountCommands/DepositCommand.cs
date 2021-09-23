using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Response;
using System.Collections.Generic;

namespace BankApplication.AccountCommands
{
    public class DepositCommand : Command
    {
        public override void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (accountRepository.Exist(accountEvent.Destination))
            {
                DepositValue(accountRepository, accountEvent);
            }
            else
            {
                CreateAccountWithInitialBalance(accountRepository, accountEvent);
            }
        }

        private void DepositValue(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            var balance = accountRepository.Get(accountEvent.Destination);

            var newBalanceValue = accountEvent.Balance + balance.balance_value;

            accountRepository.UpdateBalance(accountEvent.Destination, new Domain.Entities.Balance()
            {
                balance_value = newBalanceValue
            });

            var result = new CommandResponse()
            {
                Deposit = new DepositResponse()
                {
                    destination = new Destination()
                    {
                        id = accountEvent.Destination,
                        balance = newBalanceValue
                    }
                }
            };

            this.Result = result.Deposit;
        }

        private void CreateAccountWithInitialBalance(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            accountRepository.Create(accountEvent.Destination, new Domain.Entities.Balance()
            {
                balance_value = accountEvent.Balance
            });

            var result = new CommandResponse()
            {
                Deposit = new DepositResponse()
                {
                    destination = new Destination()
                    {
                        id = accountEvent.Destination,
                        balance = accountEvent.Balance
                    }
                }
            };

            this.Result = result.Deposit;
        }
    }
}
