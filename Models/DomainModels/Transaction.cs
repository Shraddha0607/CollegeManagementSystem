using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.DomainModels;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required(ErrorMessage = "Amount must be added")]
    [Range(100, 500, ErrorMessage = "Amount must be between 100 and 500")]
    public double Amount { get; set; }

    [Required(ErrorMessage = "Source must be mention")]
    [MaxLength(50, ErrorMessage = "Upto 50 characters allowed!")]
    public string Source { get; set; }

    public int ApplicantId { get; set; }
    public Applicant Applicant { get; set; }
}