namespace Crypto_Portfolio_Manager.Data.Model
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public required string Symbol { get; set; }
        public required decimal Amount { get; set; }
        public decimal? Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
