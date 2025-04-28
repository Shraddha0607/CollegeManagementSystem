using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CollegeApp.Models.Dtos.ResponseModels;

public class StudentResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Dob {get; set;}
    public string Course { get; set; }
    public string Email {get; set;}
    public string AadharNo {get; set;}
    public double Percentage { get; set; }
}