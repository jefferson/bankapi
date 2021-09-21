using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IAccountRepository: IDisposable
    {
        void CreateAccount(Balance balance);
    }
}
