using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.DomainModels;

public class Marks
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public double Percentage {  get; set; }
}
