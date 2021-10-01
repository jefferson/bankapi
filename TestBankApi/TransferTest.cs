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
using Microsoft.AspNetCore.Http;

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

            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(TransferCommand)))
                .Returns(new TransferCommand());

            serviceProvider
                .Setup(x => x.GetService(typeof(DepositCommand)))
                .Returns(new DepositCommand());

            var commandFactory = new CommandFactory(serviceProvider.Object);
            accountInvoker = new AccountInvoker(accountReceiver, commandFactory);
        }

        [Fact]
        public void TransferAccountNotExistShouldFailTest()
        {
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = EventEnum.Transfer,
                Amount = 10,
                Destination = "2"
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            var result = accountInvoker.GetResult();

            result.StatusCodes.Should().Be(StatusCodes.Status404NotFound);
            result.Content.Should().Be(0);

        }

        [Fact]
        public void TransferBetweenExistAccounShouldNotFailTest()
        {

            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = EventEnum.Deposit,
                Amount = 20
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = EventEnum.Transfer,
                Amount = 10,
                Destination = "2"
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            var result = accountInvoker.GetResult();

            ((TransferResponse)result.Content).Should().BeOfType(typeof(TransferResponse));

            ((TransferResponse)result.Content).origin.balance.Should().Be(10);

            ((TransferResponse)result.Content).origin.id.Should().Be("1");

            ((TransferResponse)result.Content).destination.id.Should().Be("2");

            ((TransferResponse)result.Content).destination.balance.Should().Be(10);
        }

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
