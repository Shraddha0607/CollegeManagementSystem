using System.ComponentModel.DataAnnotations;
using OnRideApp.Common;

namespace CollegeApp.Models.Dtos.RequestModels;

public class DepartmentRequest
{
    public int Id {get; set; }
    [RegularExpression(RegexPatterns.AlphaOnly, ErrorMessage = "Only alphabets allowed!")]
    [Required(ErrorMessage = "Name is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    public string Name { get; set; }
}