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
    public class WithdrawTest: IDisposable
    {
        private BalanceRepository balanceRepositoy;
        private readonly AccountInvoker accountInvoker;

        public WithdrawTest()
        {
            var dataBucket = new DataBucket();
            balanceRepositoy = new BalanceRepository(dataBucket);
            var accountRepositoy = new AccountRepository(balanceRepositoy);
            var accountReceiver = new AccountReceiver(accountRepositoy);

            var serviceProvider = new Mock<IServiceProvider>();
            
            serviceProvider
                .Setup(x => x.GetService(typeof(WithdrawCommand)))
                .Returns(new WithdrawCommand());

            serviceProvider
                .Setup(x => x.GetService(typeof(DepositCommand)))
                .Returns(new DepositCommand());

            var commandFactory = new CommandFactory(serviceProvider.Object);

            accountInvoker = new AccountInvoker(accountReceiver, commandFactory);
        }

        [Fact]
        public void WithdrawAccountNotExistShouldFailTest()
        {
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = EventEnum.Withdraw,
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            var result = accountInvoker.GetResult();

            result.StatusCodes.Should().Be(StatusCodes.Status404NotFound);
            result.Content.Should().Be(0);
        }

        [Fact]
        public void WithdrawInExistAccounShouldNotFailTest()
        {

            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = EventEnum.Deposit,
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = EventEnum.Withdraw,
                Amount = 5
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();


            var result = accountInvoker.GetResult();

            result.Content.Should().BeOfType(typeof(WithdrawResponse));

            ((WithdrawResponse)result.Content).origin.balance.Should().Be(5);

            ((WithdrawResponse)result.Content).origin.id.Should().Be("1");
        }


        [Fact]
        public void WithdrawWithNoFundsAccounShouldFailTest()
        {

            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = EventEnum.Deposit,
                Amount = 2
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = EventEnum.Withdraw,
                Amount = 5
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();


            var result = accountInvoker.GetResult();

            result.StatusCodes.Should().Be(StatusCodes.Status406NotAcceptable);
            result.Content.Should().Be("Insufficient Funds");
        }

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
