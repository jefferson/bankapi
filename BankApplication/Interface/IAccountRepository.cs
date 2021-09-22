using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IAccountRepository: IDisposable
    {
        void Create(long id);

        void UpdateBalance(long id, Balance balance);
    }
}
