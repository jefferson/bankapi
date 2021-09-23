using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IAccountRepository: IDisposable
    {
        void Create(string id, Balance balance);

        void UpdateBalance(string id, Balance balance);

        bool Exist(string id);
        Balance Get(string id);
    }
}
