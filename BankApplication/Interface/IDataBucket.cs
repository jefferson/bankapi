using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IDataBucket: IDisposable
    {
        bool Contains(long id);

        void SetValue(long id, decimal balance_value);

        void Create(long id, Balance balance);

        Balance Get(long id);
    }
}
