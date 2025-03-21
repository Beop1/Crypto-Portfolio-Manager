using Crypto_Portfolio_Manager.Data;
using Crypto_Portfolio_Manager.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Crypto_Portfolio_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionDbContext dbContext;

        public TransactionsController(TransactionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionModel>>> GetAllTransactions()
        {
            var transactions = await dbContext.Transactions.ToListAsync();
            if (transactions is null) return NotFound();

            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionModel>> GetTransaction(Guid id)
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<AddTransactionDTO>> PostTransaction(AddTransactionDTO addTransactioDTO)
        {
            var newTransaction = new TransactionModel()
            {
                Symbol = addTransactioDTO.Symbol,
                Amount = addTransactioDTO.Amount,
                Price = addTransactioDTO.Price,
                PurchaseDate = addTransactioDTO.PurchaseDate,
                TotalCost = addTransactioDTO.TotalCost,
            };

            dbContext.Transactions.Add(newTransaction);
            await dbContext.SaveChangesAsync();

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(Guid id)
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();

            dbContext.Transactions.Remove(transaction);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaction(Guid id, UpdateTransactionDTO updateTransactionDTO)
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            if (transaction is null) return NotFound(id);

            transaction.Symbol = updateTransactionDTO.Symbol;
            transaction.Amount = updateTransactionDTO.Amount;
            transaction.Price = updateTransactionDTO.Price;
            transaction.PurchaseDate = updateTransactionDTO.PurchaseDate;
            transaction.TotalCost = updateTransactionDTO.TotalCost;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
