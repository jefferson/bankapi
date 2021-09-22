using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Dtos.Request
{
    public class EventRequest
    {
        public string Type { get; set; }
        public long Destination { get; set; }
        public decimal Amount { get; set; }
        public long Origin { get; set; }
    }
}
