using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Repositories;

public class StaffRepo : IStaffRepo
{
    protected readonly CollegeDbContext dbContext;

    public StaffRepo(CollegeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<MessageResponse> AddAsync(StaffRequest staffRequest)
    {
        var isValid = await dbContext.Departments
            .AsNoTracking()
            .AnyAsync(x => x.Id == staffRequest.DepartmentId);

        if (!isValid)
        {
            throw new CustomException("Department Id not found");
        }

        Staff staff = new Staff
        {
            Name = staffRequest.Name,
            Dob = staffRequest.Dob,
            DepartmentId = staffRequest.DepartmentId,
            Position = staffRequest.Position,
            PhotoUrl = staffRequest.PhotoUrl,
        };

        await dbContext.Staffs.AddAsync(staff);
        await dbContext.SaveChangesAsync();
        return new MessageResponse { Message = "Added successfully." };
    }

    public async Task<List<StaffResponse>> GetAllAsync()
    {
        var staffs = await dbContext.Staffs
            .Select(x => new StaffResponse
            {
                Name = x.Name,
                Dob = x.Dob,
                DepartmentName = x.Department.Name,
                Position = x.Position.ToString(),
                PhotoUrl = x.PhotoUrl,
            })
            .ToListAsync();

        return staffs;
    }

    public async Task<StaffResponse> GetByIdAsync(int id)
    {
        var staff = await dbContext.Staffs
            .AsNoTracking()
            .Include(x => x.Department)
            .Select(x => new StaffResponse
            {
                Id = x.Id,
                Name = x.Name,
                Dob = x.Dob,
                DepartmentName = x.Department.Name,
                Position = x.Position.ToString(),
                PhotoUrl = x.PhotoUrl,
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (staff == null)
        {
            throw new CustomException("Invalid Id!");
        }

        return staff;
    }
}