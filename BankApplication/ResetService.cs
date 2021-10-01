using BankApplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    class ResetService : IResetService
    {
        private readonly IBalanceRepository balanceRepository;

        public ResetService(IBalanceRepository balanceRepository)
        {
            this.balanceRepository = balanceRepository;
        }


        public void Dispose()
        {
            this.balanceRepository.Dispose();
        }

    }
}
