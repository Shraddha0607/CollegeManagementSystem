namespace CollegeApp.Models.Dtos.ResponseModels;

public class StaffResponse
{
    public string Name { get; set; }

    public DateOnly Dob { get; set; }
    public string DepartmentName { get; set; }
    public string Position { get; set; }
    public string? PhotoUrl { get; set; }
}