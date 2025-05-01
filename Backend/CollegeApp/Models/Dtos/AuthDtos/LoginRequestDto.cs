using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models.Dtos.AuthDtos;

public class LoginRequestDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
