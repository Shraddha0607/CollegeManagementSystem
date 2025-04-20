using System.ComponentModel.DataAnnotations;
using CollegeApp.Models.DomainModels;

namespace CollegeApp.Models.Dtos.ResponseModels;

public class ApplicantResponse
{
    public string Name { get; set; }
    public string AadharNo { get; set; }
    public string Course { get; set; }
    public int DepartmentId { get; set; }
    public int Session { get; set; }
    public string Email { get; set; }
}
