﻿using BankApplication.AccountCommands.Helper;

namespace BankApplication.Interface
{
    public interface IAccountInvoker
    {
        void ExecuteCommand();
        void SetCommand(AccountEvent accountEvent);
        object GetResult();
    }
}