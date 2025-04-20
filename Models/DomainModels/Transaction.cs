using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.DomainModels;

public class Transaction
{
    public int Id { get; set; }
    [Required ]
    public DateTime DateTime { get; set; }
    [Required (ErrorMessage = "Price must be added")]
    [Range(100, 500, ErrorMessage = "Price must be between 100 and 500")]
    public double Price { get; set; }
    
    [Required(ErrorMessage ="Source must be mention")]
    public string Source { get; set; }
    public int ApplicantId { get; set; }
    public Applicant Applicant {get; set;}
}