using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories;

public interface ITransactionRepo
{
    Task<TransactionResponse> GetByIdAsync(int id);

    Task<MessageResponse> AddAsync(TransactionRequest transactionRequest);
}