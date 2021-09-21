using BankApplication.Interface;
using BankInfrastructure;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using static FluentAssertions.FluentActions;

namespace TestBankApi
{
    public class BalanceServiceTest : IDisposable
    {
        private readonly Mock<IBalanceRepository> mockRepository;

        public BalanceServiceTest()
        {
            mockRepository = new Mock<IBalanceRepository>();
        }

        [Fact]
        public void BalanceDoesntExistTest()
        {
            mockRepository.Setup(x => x.Get(0)).Throws(new KeyNotFoundException());

            var balance = mockRepository.Object;

            Invoking(() => balance.Get(0)).Should().Throw<KeyNotFoundException>();

        }

        public void Dispose()
        {
        }
    }
}
