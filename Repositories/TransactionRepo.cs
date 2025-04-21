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
                .FirstOrDefaultAsync(x => x.Id == transactionRequest.ApplicantId);

            if (applicant == null)
            {
                throw new CustomException("Applicant Id not found!");
            }

            Transaction transaction = new Transaction
            {
                DateTime = DateTime.Now,
                Amount = transactionRequest.Amount,
                Source = transactionRequest.Source,
                ApplicantId = transactionRequest.ApplicantId,
                Applicant = applicant,
            };

            await dbContext.Transactions.AddAsync(transaction);
            await dbContext.SaveChangesAsync();

            return new MessageResponse { Message = "Transaction added successfully!" };
        }

        public async Task<TransactionResponse> GetByIdAsync(int id)
        {
            var transaction = await dbContext.Transactions.FindAsync(id);

            if (transaction == null)
            {
                throw new CustomException("Invalid transaction id!");
            }

            TransactionResponse response = new TransactionResponse
            {
                DateTime = transaction.DateTime,
                Amount = transaction.Amount,
                Source = transaction.Source,
                ApplicantId = id
            };

            return response;
        }
    }
}