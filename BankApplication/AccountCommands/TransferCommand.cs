using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Response;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BankApplication.AccountCommands
{
    public class TransferCommand : ICommand
    {
        private (int StatusCodes, object Content) _Result;

        (int StatusCodes, object Content) ICommand.Result => _Result;

        public void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (accountRepository.Exist(accountEvent.Origin))
            {
                CreateDestinationAccountIfNotExist(accountRepository, accountEvent);
                TransferValue(accountRepository, accountEvent);
            }
            else
            {
                this._Result = (StatusCodes.Status404NotFound, 0);
            }
        }

        private void CreateDestinationAccountIfNotExist(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (!accountRepository.Exist(accountEvent.Destination))
            {
                accountRepository.Create(accountEvent.Destination, new Domain.Entities.Balance()
                {
                    balance_value = 0
                });
            }
        }

        private void TransferValue(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            
            var originBalance = accountRepository.Get(accountEvent.Origin);

            var newOriginBalance = originBalance.balance_value - accountEvent.Amount;

            var destinationBalance = accountRepository.Get(accountEvent.Destination);

            var newDestinationBalance = destinationBalance.balance_value + accountEvent.Amount;                

            accountRepository.UpdateBalance(accountEvent.Origin, new Domain.Entities.Balance()
            {
                balance_value = newOriginBalance
            });

            accountRepository.UpdateBalance(accountEvent.Destination, new Domain.Entities.Balance()
            {
                balance_value = newDestinationBalance
            });

            var result = new CommandResponse()
            {
                Transfer = new TransferResponse()
                {
                    destination = new Destination()
                    {
                        id = accountEvent.Destination,
                        balance = newDestinationBalance
                    },
                    origin = new Origin()
                    {
                        id = accountEvent.Origin,
                        balance = newOriginBalance
                    }
                }
            };

            this._Result = (StatusCodes.Status201Created, result.Transfer);
        }

    }
}
