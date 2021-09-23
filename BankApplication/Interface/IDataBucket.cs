using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IDataBucket: IDisposable
    {
        bool Contains(string id);

        void SetValue(string id, decimal balance_value);

        void Create(string id, Balance balance);

        Balance Get(string id);
    }
}
