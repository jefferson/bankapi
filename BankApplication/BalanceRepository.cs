using BankApplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace BankApplication
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IDataBucket _dataBucket;

        public BalanceRepository(IDataBucket dataBucket)
        {
            _dataBucket = dataBucket;
        }

        public Balance Get(long id)
        {
            if(_dataBucket.Contains(id))
            {
                return _dataBucket.Get(id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void Set(long id, Balance balance)
        {
            try
            {
                if (_dataBucket.Contains(id))
                {
                    _dataBucket.SetValue(id, balance.balance_value);
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

        public void Create(long id, Balance balance) => _dataBucket.Create(id, balance);

        public void Dispose() => _dataBucket.Dispose();

        public bool Exist(long id)
        {
            return _dataBucket.Contains(id);
        }
    }
}
