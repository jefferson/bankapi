using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Dtos.Request
{
    public class EventRequest
    {
        public string Type { get; set; }
        public string Destination { get; set; }
        public decimal Amount { get; set; }
        public string Origin { get; set; }
    }
}
