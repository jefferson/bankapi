using BankApplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankInfrastructure
{
    public class DataBucket : IDataBucket
    {
        private static readonly Dictionary<string, Balance> balanceInMemory = new Dictionary<string, Balance>();

        public bool Contains(string id)
        {
            return balanceInMemory.ContainsKey(id);
        }        

        public Balance Get(string id)
        {
            return balanceInMemory[id];
        }

        public void SetValue(string id, decimal balance_value)
        {
            balanceInMemory[id].balance_value = balance_value;
        }

        public void Dispose() => balanceInMemory.Clear();

        public void Create(string id, Balance balance)
        {
            balanceInMemory.Add(id, balance);
        }
    }
}
