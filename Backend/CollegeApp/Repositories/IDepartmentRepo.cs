using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public interface IDepartmentRepo
    {
        Task<MessageResponse> AddAsync(DepartmentRequest departmentRequest);
        Task<List<CourseResponse>> GetByIdAsync(int id);
        Task<List<DepartmentResponse>> GetAllDepartment();
    }
}