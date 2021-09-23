using BankApplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankInfrastructure
{
    public class DataBucket : IDataBucket
    {
        private static readonly Dictionary<long, Balance> balanceInMemory = new Dictionary<long, Balance>();

        public bool Contains(long id)
        {
            return balanceInMemory.ContainsKey(id);
        }        

        public Balance Get(long id)
        {
            return balanceInMemory[id];
        }

        public void SetValue(long id, decimal balance_value)
        {
            balanceInMemory[id].balance_value = balance_value;
        }

        public void Dispose() => balanceInMemory.Clear();

        public void Create(long id, Balance balance)
        {
            balanceInMemory.Add(id, balance);
        }
    }
}
