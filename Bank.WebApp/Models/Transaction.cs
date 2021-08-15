namespace Bank.WebApp.Models
{
    public class Transaction
    {
        public int Amount { get; set; }
        public int Balance { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
