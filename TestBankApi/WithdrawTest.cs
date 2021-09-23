using BankApplication;
using BankApplication.AccountCommands;
using BankApplication.Response;
using BankInfrastructure;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using static FluentAssertions.FluentActions;

namespace TestBankApi
{
    public class WithdrawTest: IDisposable
    {
        private readonly AccountInvoker accountInvoker;
        private readonly BalanceRepository balanceRepositoy;

        public WithdrawTest()
        {
            var dataBucket = new DataBucket();
            balanceRepositoy = new BalanceRepository(dataBucket);
            var accountRepositoy = new AccountRepository(balanceRepositoy);
            var accountReceiver = new AccountReceiver(accountRepositoy);
            accountInvoker = new AccountInvoker(accountReceiver);
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

        public void Dispose()
        {
            balanceRepositoy.Dispose();
        }

    }
}
