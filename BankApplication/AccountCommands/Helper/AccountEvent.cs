namespace BankApplication.AccountCommands.Helper
{
    public class AccountEvent
    {
        public long Destination { get; set; }

        public decimal Balance { get; set; }

        public string Type { get; set; }
    }
}
