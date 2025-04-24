using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.DomainModels;

public class Course
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    public string Name { get; set; }
    public int DepartmentId {get; set; }
}