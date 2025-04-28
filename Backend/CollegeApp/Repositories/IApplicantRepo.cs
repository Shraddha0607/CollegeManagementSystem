using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public interface IApplicantRepo
    {
        Task<MessageResponse> AddAsync(ApplicantRequest applicantRequest);
        Task<List<ApplicantResponse>> GetAllAsync();
        Task<ApplicantResponse> GetByIdAsync(int id);
        Task<MessageResponse> DeleteAsync(int id);
        Task<MessageResponse> UpdateAsync(ApplicantRequest applicantRequest);
    }
}