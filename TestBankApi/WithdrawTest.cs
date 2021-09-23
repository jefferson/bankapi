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
            var commandFactory = new CommandFactory();
            accountInvoker = new AccountInvoker(accountReceiver, commandFactory);
        }

        [Fact]
        public void WithdrawAccountNotExistShouldFailTest()
        {
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = "withdraw",
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            Invoking(() => accountInvoker.ExecuteCommand()).Should().Throw<KeyNotFoundException>();
        }

        [Fact]
        public void WithdrawInExistAccounShouldNotFailTest()
        {

            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = "deposit",
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Origin = "1",
                Type = "withdraw",
                Amount = 5
            };

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();


            var result = (WithdrawResponse)accountInvoker.GetResult();

            result.Should().BeOfType(typeof(WithdrawResponse));

            result.origin.balance.Should().Be(5);

            result.origin.id.Should().Be("1");
        }

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
