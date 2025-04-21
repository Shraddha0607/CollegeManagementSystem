using System.Transactions;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories;

public interface ITransactionRepo
{
    Task<MessageResponse> AddTransactionAsync(Transaction transaction);

    Task<TransactionResponse> GetTransactionByIdAsync(int transactionId);
}