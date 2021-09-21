using BankApplication;
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
        private readonly Mock<DataBucket> mockDataBucket;
        private readonly Mock<BalanceRepository> mockRepository;

        public BalanceServiceTest()
        {
            mockDataBucket = new Mock<DataBucket>();
            mockRepository = new Mock<BalanceRepository>(mockDataBucket.Object);
        }

        [Fact]
        public void BalanceDoesntExistTest()
        {
            var balance = mockRepository.Object;
            Invoking(() => balance.Get(0)).Should().Throw<KeyNotFoundException>();
        }

        [Fact]
        public void BalanceExistTest()
        {
            var balance = mockRepository.Object;

            balance.Create(1);

            balance.Set(1, new Domain.Entities.Balance() { 
                balance_value = 10
            });

            balance.Get(1).balance_value.Should().Be(10);
        }

        public void Dispose()
        {
        }
    }
}
