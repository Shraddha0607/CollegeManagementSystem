using System.Transactions;
using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly CollegeDbContext dbContext;

        public TransactionRepo(CollegeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MessageResponse> AddTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionResponse> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);
            if (transaction == null)
            {
                throw new CustomException("Transaction Id  is not found!");
            }
            throw new NotImplementedException();
        }
    }
}