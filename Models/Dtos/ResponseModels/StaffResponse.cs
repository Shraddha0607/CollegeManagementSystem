using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Enums;

namespace CollegeApp.Models.Dtos.ResponseModels;

public class StaffResponse
{
    public string Name { get; set; }

    public DateOnly Dob { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public Position Position { get; set; }
    public string? PhotoUrl { get; set; }
}