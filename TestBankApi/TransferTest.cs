using BankApplication;
using BankApplication.AccountCommands;
using BankApplication.Response;
using BankInfrastructure;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using static FluentAssertions.FluentActions;
using Moq;
using BankApplication.Interface;
using BankApplication.AccountCommands.Helper;

namespace TestBankApi
{
    public class TransferTest: IDisposable
    {
        private BalanceRepository balanceRepositoy;
        private readonly AccountInvoker accountInvoker;

        public TransferTest()
        {
            var dataBucket = new DataBucket();
            balanceRepositoy = new BalanceRepository(dataBucket);
            var accountRepositoy = new AccountRepository(balanceRepositoy);
            var accountReceiver = new AccountReceiver(accountRepositoy);
            var commandFactory = new CommandFactory();
            accountInvoker = new AccountInvoker(accountReceiver, commandFactory);
        }

        [Fact]
        public void TransferAccountNotExistShouldFailTest()
        {
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = "transfer",
                Amount = 10,
                Destination = "2"
            };

            accountInvoker.SetCommand(account_event);

            Invoking(() => accountInvoker.ExecuteCommand()).Should().Throw<KeyNotFoundException>();
        }

        [Fact]
        public void TransferBetweenExistAccounShouldNotFailTest()
        {

            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = "deposit",
                Amount = 20
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = "transfer",
                Amount = 10,
                Destination = "2"
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            var result = (TransferResponse)accountInvoker.GetResult();

            result.Should().BeOfType(typeof(TransferResponse));

            result.origin.balance.Should().Be(10);

            result.origin.id.Should().Be("1");

            result.destination.id.Should().Be("2");

            result.destination.balance.Should().Be(10);
        }

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
