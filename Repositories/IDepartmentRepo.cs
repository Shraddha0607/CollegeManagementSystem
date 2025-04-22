using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public interface IDepartmentRepo
    {
        Task<MessageResponse> AddAsync(DepartmentRequest departmentRequest);
    }
}