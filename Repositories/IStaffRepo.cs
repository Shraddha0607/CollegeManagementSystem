using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public interface IStaffRepo
    {
        Task<StaffResponse> GetByIdAsync(int id);

        Task<MessageResponse> AddAsync(StaffRequest staffRequest);

        Task<List<StaffResponse>> GetAllAsync();
    }
}