using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using BankApplication;
using BankApplication.AccountCommands;
using BankInfrastructure;
using BankApplication.AccountCommands.Helper;
using Moq;

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
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(DepositCommand)))
                .Returns(new DepositCommand());

            var commandFactory = new CommandFactory(serviceProvider.Object);

            var command = commandFactory.ResolveCommand(new AccountEvent()
            {
                Type = EventEnum.Deposit
            });

            command.command.Should().BeOfType<DepositCommand>();
        }

        [Fact]
        public void CreateInstaceOfWithdrawCommandShouldBeSuccess()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(WithdrawCommand)))
                .Returns(new WithdrawCommand());

            var commandFactory = new CommandFactory(serviceProvider.Object);

            var command = commandFactory.ResolveCommand(new AccountEvent()
            {
                Type = EventEnum.Withdraw
            });

            command.command.Should().BeOfType<WithdrawCommand>();
        }

        [Fact]
        public void CreateInstaceOfTransferCommandShouldBeSuccess()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(TransferCommand)))
                .Returns(new TransferCommand());

            var commandFactory = new CommandFactory(serviceProvider.Object);

            var command = commandFactory.ResolveCommand(new AccountEvent()
            {
                Type = EventEnum.Transfer
            });

            command.command.Should().BeOfType<TransferCommand>();
        }

    }
}
