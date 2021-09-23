﻿using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Response;
using System.Collections.Generic;

namespace BankApplication.AccountCommands
{
    public class TransferCommand : Command
    {
        public override void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (accountRepository.Exist(accountEvent.Origin))
            {
                CreateDestinationAccountIfNotExist(accountRepository, accountEvent);
                TransferValue(accountRepository, accountEvent);
            }
            else
            {
                throw new KeyNotFoundException();
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

            this.Result = result.Transfer;
        }

    }
}