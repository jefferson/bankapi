using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using BankApplication;
using BankApplication.AccountCommands;
using BankInfrastructure;
using BankApplication.AccountCommands.Helper;

namespace TestBankApi
{
    public class CommandTest
    {
        [Fact]
        public void EnumDepositShouldBeDeposit()
        {
            EventEnum.Deposit.Should().Be("deposit");
        }

        [Fact]
        public void EnumWithdrawMustBeWithdraw()
        {
            EventEnum.Withdraw.Should().Be("withdraw");
        }


        [Fact]
        public void EnumTransferMustBeTransfer()
        {
            EventEnum.Transfer.Should().Be("transfer");
        }

        [Fact]
        public void CreateInstaceOfDepositCommandShouldBeSuccess()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.Build(new AccountEvent()
            {
                Type = EventEnum.Deposit
            });

            command.command.Should().BeOfType<DepositCommand>();
        }

        [Fact]
        public void CreateInstaceOfWithdrawCommandShouldBeSuccess()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.Build(new AccountEvent()
            {
                Type = EventEnum.Withdraw
            });

            command.command.Should().BeOfType<WithdrawCommand>();
        }

        [Fact]
        public void CreateInstaceOfTransferCommandShouldBeSuccess()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.Build(new AccountEvent()
            {
                Type = EventEnum.Transfer
            });

            command.command.Should().BeOfType<TransferCommand>();
        }

    }
}
