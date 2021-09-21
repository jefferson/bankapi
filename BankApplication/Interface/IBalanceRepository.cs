using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IBalanceRepository : IDisposable
    {
        Balance Get(int id);

        void Set(int id, Balance balance);
    }
}
