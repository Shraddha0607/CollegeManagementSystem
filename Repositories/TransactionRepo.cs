using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {
        protected readonly CollegeDbContext dbContext;

        public TransactionRepo(CollegeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MessageResponse> AddAsync(TransactionRequest transactionRequest)
        {
            var applicant = await dbContext.Applicants
                .AnyAsync(x => x.Id == transactionRequest.ApplicantId);

            if (!applicant)
            {
                throw new CustomException("Applicant Id not found!");
            }

            Transaction transaction = new Transaction
            {
                DateTime = DateTime.Now,
                Amount = transactionRequest.Amount,
                Source = transactionRequest.Source,
                ApplicantId = transactionRequest.ApplicantId,
            };

            await dbContext.Transactions.AddAsync(transaction);
            await dbContext.SaveChangesAsync();

            return new MessageResponse { Message = "Transaction added successfully!" };
        }

        public async Task<TransactionResponse> GetByIdAsync(int id)
        {
            var transaction = await dbContext.Transactions
                .Select(x => new TransactionResponse
                {
                    Id = x.Id,
                    DateTime = x.DateTime,
                    Amount = x.Amount,
                    Source = x.Source,
                    ApplicantId = x.ApplicantId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (transaction == null)
            {
                throw new CustomException("Invalid transaction id!");
            }

            return transaction;
        }
    }
}