using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.AspNetCore.Mvc;
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
            .FirstOrDefaultAsync(x => x.AadharNo == studentRequest.AadharNo || x.Email == studentRequest.Email);

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
        var student = await dbContext.Students.FindAsync(id);
        if (student == null)
        {
            throw new CustomException("Invalid Id");
        }

        var percentage = await dbContext.Marks
            .FirstOrDefaultAsync(x => x.StudentId == id);

        if (percentage == null)
        {
            throw new CustomException("Percentage not found for id!");
        }

        StudentResponse studentResponse = new StudentResponse
        {
            Name = student.Name,
            Course = student.Course,
            Percentage = percentage.Percentage,
        };

        return studentResponse;
    }

    public async Task<List<StudentResponse>> GetTopFive()
    {
        var students = await dbContext.Marks
                .Include(x => x.Student)
                .Select(x => new StudentResponse
                {
                    Name = x.Student.Name,
                    Course = x.Student.Course,
                    Percentage = x.Percentage,
                })
                .OrderByDescending(x => x.Percentage)
                .Take(5)
                .ToListAsync();

        return students;
    }

    [HttpPost]
    public async Task<MessageResponse> AddMarks(int studentId, double percentage)
    {
        var student = await dbContext.Students.FindAsync(studentId);
        if (student == null)
        {
            throw new CustomException("Student Id not found!");
        }

        Marks mark = new Marks
        {
            StudentId = studentId,
            Student = student,
            Percentage = percentage,
        };

        await dbContext.Marks.AddAsync(mark);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Saved successfully!" };
    }
}