using System.ComponentModel.DataAnnotations;
using OnRideApp.Common;

namespace CollegeApp.Models.Dtos.RequestModels;

public class StudentRequest
{
    [Required(ErrorMessage = "Name is required!")]
    [RegularExpression(RegexPatterns.AlphaOnly, ErrorMessage = "Only Alphabet allowed!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date of birth is required!")]
    public int Dob { get; set; }

    [Required(ErrorMessage = "Course is required!")]
    public string Course { get; set; }

    [Required(ErrorMessage = "Aadhar number is required!")]
    [MinLength(10, ErrorMessage = "Aadhar number must have 10 character!")]
    [MaxLength(10, ErrorMessage = "Aadhar number length must be 10")]
    [RegularExpression(RegexPatterns.NumberOnly, ErrorMessage = "Only numbers allowed!")]
    public string AadharNo { get; set; }

    [Required(ErrorMessage = "Email Id is required!")]
    [EmailAddress(ErrorMessage = "Email Id is not in correct format!")]
    [MaxLength(20, ErrorMessage = "Only 20 characters allowed!")]
    public string Email { get; set; }
}