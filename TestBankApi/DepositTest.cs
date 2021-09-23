using BankApplication;
using BankApplication.AccountCommands;
using BankApplication.Interface;
using BankApplication.Response;
using BankInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using BankApplication.AccountCommands.Helper;

namespace TestBankApi
{
    public class DepositTest: IDisposable
    {
        private readonly AccountInvoker accountInvoker;
        private readonly BalanceRepository balanceRepositoy;

        public DepositTest()
        {
            var dataBucket = new DataBucket();
            balanceRepositoy = new BalanceRepository(dataBucket);
            var accountRepositoy = new AccountRepository(balanceRepositoy);
            var accountReceiver = new AccountReceiver(accountRepositoy);
            var commandFactory = new CommandFactory();
            accountInvoker = new AccountInvoker(accountReceiver, commandFactory);
        }

        [Fact]
        public void CreateAccountWithInitialBalanceWithSucessTest()
{
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = "deposit",
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            var result = (DepositResponse) accountInvoker.GetResult();

            result.Should().BeOfType(typeof(DepositResponse));

            result.destination.balance.Should().Be(10);

            result.destination.id.Should().Be("1");

        }

        [Fact]
        public void DepositValueForExistAccountWithSuccess()
        {
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = "deposit",
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            account_event.Amount = 15;

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            var result = (DepositResponse)accountInvoker.GetResult();

            result.Should().BeOfType(typeof(DepositResponse));

            result.destination.balance.Should().Be(25);

            result.destination.id.Should().Be("1");

        }

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
