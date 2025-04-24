using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.Dtos.ResponseModels;

public class TransactionResponse
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }

    public double Amount { get; set; }
    public int ApplicantId { get; set; }
    public string Source { get; set; }
}