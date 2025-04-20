using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Exceptions;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Repositories;

public class ApplicantRepo : IApplicantRepo
{
    public readonly CollegeDbContext dbContext;
    public readonly ILogger logger;
    public readonly IMapper mapper;

    public ApplicantRepo(CollegeDbContext dbContext,
        IMapper mapper,
        ILogger<ApplicantRepo> logger)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<MessageResponse> AddAsync(ApplicantRequest applicantRequest)
    {
        var isValidAadhaar = await dbContext.Applicants.AnyAsync(x => x.AadharNo == applicantRequest.AadharNo);
        if (isValidAadhaar)
        {
            throw new CustomException("Aadhar already exists!");
        }

        var isValidEmail = await dbContext.Applicants.AnyAsync(x => x.Email == applicantRequest.Email);
        if (isValidEmail)
        {
            throw new CustomException("Email already exists!");
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
        var applicants = await dbContext.Applicants.ToListAsync();
        List<ApplicantResponse> response = new List<ApplicantResponse>();

        foreach (var applicant in applicants)
        {
            var applicantResponse = new ApplicantResponse
            {
                Name = applicant.Name,
                AadharNo = applicant.AadharNo,
                Course = applicant.Course,
                DepartmentId = applicant.DepartmentId,
                Session = applicant.Session,
                Email = applicant.Email,
            };
            response.Add(applicantResponse);
        }
        return response;

    }
}