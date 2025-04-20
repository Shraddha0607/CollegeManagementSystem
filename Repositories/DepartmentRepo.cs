using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly CollegeDbContext dbContext;
        private readonly ILogger<DepartmentRepo> logger;

        public DepartmentRepo(CollegeDbContext dbContext, ILogger<DepartmentRepo> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<MessageResponse> AddAsync(DepartmentRequest departmentRequest)
        {
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
