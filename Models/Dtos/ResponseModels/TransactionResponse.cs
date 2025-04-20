using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.Dtos.ResponseModels;

public class TransactionResponse
{
    public int Id { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    public double Price { get; set; }
    public int ApplicantId { get; set; }
    public string Source { get; set; }
}
