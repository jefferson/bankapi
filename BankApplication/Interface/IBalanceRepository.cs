using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IBalanceRepository : IDisposable
    {
        Balance Get(string id);

        void Create(string id, Balance balance);

        void Set(string id, Balance balance);

        bool Exist(string id);
    }
}
