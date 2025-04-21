using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.DomainModels;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date of birth is required!")]
    [DataType(DataType.Date)]
    public DateOnly Dob { get; set; }

    [Required(ErrorMessage = "Course is required!")]
    public string Course { get; set; }

    [Required(ErrorMessage = "Aadhar number is required!")]
    [MaxLength(10, ErrorMessage = "Aadhar number length must be 10")]
    public string AadharNo { get; set; }

    [Required(ErrorMessage = "Email Id is required!")]
    [EmailAddress(ErrorMessage = "Email Id is not in correct format!")]
    [MaxLength(20, ErrorMessage = "Only 20 characters allowed!")]
    public string Email { get; set; }
}