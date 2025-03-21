namespace Crypto_Portfolio_Manager.Data
{
    public class UpdateTransactionDTO
    {
        public required string Symbol { get; set; }
        public required decimal Amount { get; set; }
        public decimal? Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
