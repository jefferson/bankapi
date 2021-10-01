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
using Moq;

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

            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(DepositCommand)))
                .Returns(new DepositCommand());

            var commandFactory = new CommandFactory(serviceProvider.Object);

            accountInvoker = new AccountInvoker(accountReceiver, commandFactory);
        }

        [Fact]
        public void CreateAccountWithInitialBalanceWithSucessTest()
{
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = EventEnum.Deposit,
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            var result = accountInvoker.GetResult();

            result.Content.Should().BeOfType(typeof(DepositResponse));

            ((DepositResponse)result.Content).destination.balance.Should().Be(10);

            ((DepositResponse)result.Content).destination.id.Should().Be("1");

        }

        [Fact]
        public void DepositValueForExistAccountWithSuccess()
        {
            var account_event = new BankApplication.AccountCommands.Helper.AccountEvent()
            {
                Destination = "1",
                Type = EventEnum.Deposit,
                Amount = 10
            };

            accountInvoker.SetCommand(account_event);

            accountInvoker.ExecuteCommand();

            account_event.Amount = 15;

            accountInvoker.SetCommand(account_event);
            accountInvoker.ExecuteCommand();

            var result = accountInvoker.GetResult();

            result.Content.Should().BeOfType(typeof(DepositResponse));

            ((DepositResponse)result.Content).destination.balance.Should().Be(25);

            ((DepositResponse)result.Content).destination.id.Should().Be("1");

        }

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
