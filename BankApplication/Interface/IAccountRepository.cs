using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IAccountRepository: IDisposable
    {
        void Create(long id, Balance balance);

        void UpdateBalance(long id, Balance balance);

        bool Exist(long id);
        Balance Get(long id);
    }
}
