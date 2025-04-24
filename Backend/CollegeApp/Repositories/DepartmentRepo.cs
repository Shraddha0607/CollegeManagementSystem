using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly CollegeDbContext dbContext;

        public DepartmentRepo(CollegeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MessageResponse> AddAsync(DepartmentRequest departmentRequest)
        {
            var isValid = dbContext.Departments.Any(x => x.Name == departmentRequest.Name);
            if (isValid)
            {
                throw new CustomException("Already existing department name! It must be unique");
            }

            Department department = new Department
            {
                Name = departmentRequest.Name,
                TotalTeacher = 0,
                Staffs = new List<Staff>(),
            };
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();

            return new MessageResponse { Message = "Added successfully." };
        }
    }
}