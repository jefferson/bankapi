namespace BankApplication.AccountCommands.Helper
{
    public class AccountEvent
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }
    }
}
