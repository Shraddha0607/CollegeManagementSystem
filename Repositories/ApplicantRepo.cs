using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Repositories;

public class ApplicantRepo : IApplicantRepo
{
    public readonly CollegeDbContext dbContext;

    public ApplicantRepo(CollegeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<MessageResponse> AddAsync(ApplicantRequest applicantRequest)
    {
        var isValid = await dbContext.Applicants
            .Select(x => new
            {
                x.AadharNo,
                x.Email
            })
            .FirstOrDefaultAsync(x => x.AadharNo == applicantRequest.AadharNo ||
                x.Email == applicantRequest.Email);

        if (isValid != null)
        {
            if (isValid.AadharNo == applicantRequest.AadharNo)
            {
                throw new CustomException("Aadhar already exists!");
            }
            else
            {
                throw new CustomException("Email already exists!");
            }
        }

        var department = await dbContext.Departments.FindAsync(applicantRequest.DepartmentId);
        if (department == null)
        {
            throw new CustomException("Invalid Department Id!");
        }

        Applicant applicant = new Applicant
        {
            Name = applicantRequest.Name,
            AadharNo = applicantRequest.AadharNo,
            Course = applicantRequest.Course,
            Department = department,
            DepartmentId = applicantRequest.DepartmentId,
            Session = applicantRequest.Session,
            Email = applicantRequest.Email
        };

        var response = await dbContext.Applicants.AddAsync(applicant);
        await dbContext.SaveChangesAsync();
        return new MessageResponse { Message = "Saved Succesfully." };
    }

    public async Task<List<ApplicantResponse>> GetAllAsync()
    {
        var applicants = await dbContext.Applicants
                .Select(applicant => new ApplicantResponse
                {
                    Name = applicant.Name,
                    AadharNo = applicant.AadharNo,
                    Course = applicant.Course,
                    DepartmentId = applicant.DepartmentId,
                    Session = applicant.Session,
                    Email = applicant.Email
                }).ToListAsync();

        return applicants;
    }
}