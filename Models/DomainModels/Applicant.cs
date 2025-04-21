using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.DomainModels;

public class Applicant
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Aadhar Number is required!")]
    [MaxLength(10, ErrorMessage = "Only 10 character allowed!")]
    public string AadharNo { get; set; }

    [Required(ErrorMessage = "Course is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    public string Course { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    [Required(ErrorMessage = "Session year is required!")]
    [Range(2025, 2050, ErrorMessage = "Year is not in range!")]
    public int Session { get; set; }  // year for session

    [Required(ErrorMessage = "Email Id is required!")]
    [EmailAddress(ErrorMessage = "Email Id is not in correct format!")]
    [MaxLength(20, ErrorMessage = "Only 20 characters allowed!")]
    public string Email { get; set; }
}