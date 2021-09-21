using BankApplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace BankInfrastructure
{
    public class BalanceService : IBalanceRepository
    {

        private static readonly Dictionary<int, Balance> balanceInMemory = new Dictionary<int, Balance>();

        public Balance Get(int id)
        {
            if(balanceInMemory.ContainsKey(id))
            {
                return balanceInMemory[id];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void Set(int id, Balance balance)
        {
            try
            {
                if(balanceInMemory.ContainsKey(id))
                {
                    balanceInMemory[id] = balance;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Reset()
        {
            balanceInMemory.Clear();
        }

        public void Dispose()
        {
            balanceInMemory.Clear();
        }

        
    }
}
