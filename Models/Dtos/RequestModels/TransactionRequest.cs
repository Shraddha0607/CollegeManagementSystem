using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.Dtos.RequestModels;

public class TransactionRequest
{
    [Required(ErrorMessage = "Amount must be added")]
    [Range(100, 500, ErrorMessage = "Amount must be between 100 and 500")]
    public double Amount { get; set; }

    [Required(ErrorMessage = "Source must be mention")]
    public string Source { get; set; }

    public int ApplicantId { get; set; }
}