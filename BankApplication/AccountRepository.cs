using BankApplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    class AccountRepository : IAccountRepository
    {
        private readonly IBalanceRepository _balanceRepository;

        public AccountRepository(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public void Create(long id)
        {
            _balanceRepository.Create(id);            
        }        

        public void UpdateBalance(long id, Balance balance)
        {
            _balanceRepository.Set(id, balance);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
