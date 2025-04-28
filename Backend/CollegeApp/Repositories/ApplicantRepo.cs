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

    // public static void CreateTestMessage2(string server)
    // {
    //     string to = "jane@contoso.com";
    //     string from = "ben@contoso.com";
    //     MailMessage message = new MailMessage(from, to);
    //     message.Subject = "Using the new SMTP client.";
    //     message.Body = @"Using this new feature, you can send an email message from an application very easily.";
    //     SmtpClient client = new SmtpClient(server);
    //     // Credentials are necessary if the server requires the client
    //     // to authenticate before it will send email on the client's behalf.
    //     client.UseDefaultCredentials = true;

    //     try
    //     {
    //         client.Send(message);
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
    //             ex.ToString());
    //     }
    // }
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

        var isValidDepartment = await dbContext.Departments.AsNoTracking().AnyAsync(x => x.Id == applicantRequest.DepartmentId);
        if (!isValidDepartment)
        {
            throw new CustomException("Invalid Department Id!");
        }

        Applicant applicant = new Applicant
        {
            Name = applicantRequest.Name,
            AadharNo = applicantRequest.AadharNo,
            Course = applicantRequest.Course,
            DepartmentId = applicantRequest.DepartmentId,
            Session = applicantRequest.Session,
            Email = applicantRequest.Email
        };

        var response = await dbContext.Applicants.AddAsync(applicant);
        await dbContext.SaveChangesAsync();

        // need to send mail

        return new MessageResponse { Message = "Saved Succesfully." };
    }

    public async Task<MessageResponse> DeleteAsync(int id)
    {
        var applicant = await dbContext.Applicants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (applicant == null)
        {
            throw new CustomException("Invalid id!");
        }

        dbContext.Applicants.Remove(applicant);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Removed successfully!" };
    }

    public async Task<List<ApplicantResponse>> GetAllAsync()
    {
        var applicants = await dbContext.Applicants
                .Select(applicant => new ApplicantResponse
                {
                    Id = applicant.Id,
                    Name = applicant.Name,
                    AadharNo = applicant.AadharNo,
                    Course = applicant.Course,
                    DepartmentId = applicant.DepartmentId,
                    Session = applicant.Session,
                    Email = applicant.Email
                }).ToListAsync();

        return applicants;
    }

    public async Task<ApplicantResponse> GetByIdAsync(int id)
    {
        var applicant = await dbContext.Applicants.AsNoTracking()
            .Select(x => new ApplicantResponse
            {
                Id = x.Id,
                Name = x.Name,
                AadharNo = x.AadharNo,
                Course = x.Course,
                DepartmentId = x.DepartmentId,
                Session = x.Session,
                Email = x.Email,
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (applicant == null)
        {
            throw new CustomException("Invalid Id!");
        }

        return applicant;
    }

    public async Task<MessageResponse> UpdateAsync(ApplicantRequest applicantRequest)
    {
        var existingApplicant = await dbContext.Applicants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == applicantRequest.Id);
        if(existingApplicant == null){
            throw new CustomException("Invalid applicant id!");
        }

        existingApplicant.Name = applicantRequest.Name;
        existingApplicant.Course = applicantRequest.Course;
        existingApplicant.AadharNo = applicantRequest.AadharNo;
        if(existingApplicant.DepartmentId != applicantRequest.DepartmentId){
            var department = await dbContext.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == applicantRequest.DepartmentId);
            
            if(department == null){
                throw new CustomException("Department Id is not found!");
            }

            existingApplicant.Department = department;
            existingApplicant.DepartmentId = applicantRequest.DepartmentId;
        }
        existingApplicant.Email = applicantRequest.Email;

        dbContext.Applicants.Update(existingApplicant);
        await dbContext.SaveChangesAsync();

        return new MessageResponse { Message = "Updated successfully!"};
    }
}