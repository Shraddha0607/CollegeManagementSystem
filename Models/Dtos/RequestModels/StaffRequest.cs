using System.ComponentModel.DataAnnotations;
using CollegeApp.Models.Enums;

namespace CollegeApp.Models.Dtos.RequestModels;

public class StaffRequest
{
    [Required(ErrorMessage = "Name is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date of birth is required!")]
    public DateOnly Dob { get; set; }

    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Position is required!")]
    public Position Position { get; set; }

    public string? PhotoUrl { get; set; }
}