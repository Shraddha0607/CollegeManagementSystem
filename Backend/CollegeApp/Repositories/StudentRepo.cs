using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly CollegeDbContext dbContext;

    public StudentRepo(CollegeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<MessageResponse> AddAsync(StudentRequest studentRequest)
    {
        var isValid = await dbContext.Students
            .Select(x =>  new {
                x.AadharNo,
                x.Email
            })
            .FirstOrDefaultAsync(x => x.AadharNo == studentRequest.AadharNo
            || x.Email == studentRequest.Email);

        if (isValid != null)
        {
            if (isValid.AadharNo == studentRequest.AadharNo)
            {
                throw new CustomException("Aadhar must be unique");
            }
            else throw new CustomException("Existing Email id! ");
        }

        Student student = new Student
        {
            Name = studentRequest.Name,
            Dob = studentRequest.Dob,
            Course = studentRequest.Course,
            AadharNo = studentRequest.AadharNo,
            Email = studentRequest.Email,
        };

        await dbContext.Students.AddAsync(student);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Added successfully." };
    }

    public async Task<StudentResponse> GetByIdAsync(int id)
    {
        var response = await dbContext.Marks
            .Include(x => x.Student)
            .Select(x => new StudentResponse
            {
                Id = x.Id,
                Name = x.Student.Name,
                Course = x.Student.Course,
                Percentage = x.Percentage,
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (response == null)
        {
            throw new CustomException("Invalid Id");
        }

        return response;
    }

    public async Task<List<StudentResponse>> GetTopFive()
    {
        var students = await dbContext.Marks
                .Include(x => x.Student)
                .Select(x => new StudentResponse
                {
                    Id = x.Student.Id,
                    Name = x.Student.Name,
                    Course = x.Student.Course,
                    Percentage = x.Percentage,
                })
                .OrderByDescending(x => x.Percentage)
                .Take(5)
                .ToListAsync();

        return students;
    }

    public async Task<MessageResponse> AddMarks(int studentId, double percentage)
    {
        var student = await dbContext.Students
            .AnyAsync(x => x.Id == studentId);

        if (!student)
        {
            throw new CustomException("Student Id not found!");
        }

        Marks mark = new Marks
        {
            StudentId = studentId,
            Percentage = percentage,
        };

        await dbContext.Marks.AddAsync(mark);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Saved successfully!" };
    }
}