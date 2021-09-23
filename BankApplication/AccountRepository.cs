using BankApplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IBalanceRepository _balanceRepository;

        public AccountRepository(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public void Create(string id, Balance balance)
        {
            _balanceRepository.Create(id, balance);            
        }        

        public void UpdateBalance(string id, Balance balance)
        {
            _balanceRepository.Set(id, balance);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exist(string id)
        {
            return _balanceRepository.Exist(id);
        }

        public Balance Get(string id)
        {
            return _balanceRepository.Get(id);
        }
    }
}
