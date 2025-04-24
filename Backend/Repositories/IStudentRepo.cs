using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories;

public interface IStudentRepo
{
    Task<MessageResponse> AddAsync(StudentRequest studentRequest);

    Task<StudentResponse> GetByIdAsync(int id);

    Task<List<StudentResponse>> GetTopFive();

    Task<MessageResponse> AddMarks(int studentId, double percentage);
}