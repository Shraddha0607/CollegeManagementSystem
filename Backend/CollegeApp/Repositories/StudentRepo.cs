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
            .Select(x => new
            {
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
                Dob = x.Student.Dob,
                Email = x.Student.Email,
                AadharNo = x.Student.AadharNo,
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

    public async Task<List<StudentResponse>> GetAllAsync()
    {
        var students = await dbContext.Students
        .Join(dbContext.Marks, s => s.Id, m => m.Id, (s, m) => new StudentResponse
        {
            Id = s.Id,
            Name = s.Name,
            Course = s.Course,
            Percentage = m.Percentage,
            Dob = s.Dob,
            Email = s.Email,
            AadharNo = s.AadharNo,
        })
        .ToListAsync();

        return students;
    }

    public async Task<MessageResponse> DeleteAsync(int id)
    {
        var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (student == null)
        {
            throw new CustomException("Invalid Id!");
        }

        dbContext.Students.Remove(student);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Removed successfully." };
    }

    public async Task<MessageResponse> UpdateAsync(StudentRequest studentRequest)
    {
        var existingStudent = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == studentRequest.Id);
        if (existingStudent == null)
        {
            throw new CustomException("Student id not found!");
        }

        var isValid = await dbContext.Students
            .Select(x => new
            {
                x.Id,
                x.AadharNo,
                x.Email
            })
            .FirstOrDefaultAsync(x => (x.AadharNo == studentRequest.AadharNo
            || x.Email == studentRequest.Email) && x.Id != studentRequest.Id);

        if (isValid != null)
        {
            if (isValid.AadharNo == studentRequest.AadharNo)
            {
                throw new CustomException("Aadhar must be unique");
            }
            else throw new CustomException("Existing Email id! ");
        }

        existingStudent.Name = studentRequest.Name;
        existingStudent.Dob = studentRequest.Dob;
        existingStudent.AadharNo = studentRequest.AadharNo;
        existingStudent.Course = studentRequest.Course;
        existingStudent.Email = studentRequest.Email;

        dbContext.Students.Update(existingStudent);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Updated successfully." };
    }
}