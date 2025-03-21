using Crypto_Portfolio_Manager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Portfolio_Manager.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {

        }

        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
