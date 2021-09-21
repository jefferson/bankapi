﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Interface
{
    public interface IBalanceRepository : IDisposable
    {
        Balance Get(long id);

        void Create(long id);

        void Set(long id, Balance balance);
    }
}
