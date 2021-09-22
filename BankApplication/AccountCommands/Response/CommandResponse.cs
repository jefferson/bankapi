using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Response
{
    public class CommandResponse
    {
        public DepositResponse Deposit { get; set; }

        public WithdrawResponse Withdraw { get; set; }

        public TransferResponse Transfer { get; set; }    

    }


    #region deposit

    public class DepositResponse
    {
        public Destination destination { get; set; }
    }

    public class Destination
    {
        public long id { get; set; }
        public decimal balance { get; set; }
    }

    #endregion

    #region withdraw

    public class WithdrawResponse
    {
        public Origin origin { get; set; }
    }

    public class Origin
    {
        public string id { get; set; }
        public int balance { get; set; }
    }

    #endregion

    #region transfer

    public class TransferResponse
    {
        public Origin origin { get; set; }
        public Destination destination { get; set; }
    }
    #endregion

}
