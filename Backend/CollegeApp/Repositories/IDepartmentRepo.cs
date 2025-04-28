using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public interface IDepartmentRepo
    {
        Task<MessageResponse> AddAsync(DepartmentRequest departmentRequest);
        Task<List<CourseResponse>> GetByIdAsync(int id);
        Task<MessageResponse> DeleteByIdAsync(int id);
        Task<MessageResponse> UpdateAsync(DepartmentRequest departmentRequest);
        Task<List<DepartmentResponse>> GetAllDepartment();
    }
}