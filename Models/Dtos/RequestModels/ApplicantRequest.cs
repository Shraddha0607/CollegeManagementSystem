﻿using System.ComponentModel.DataAnnotations;
using OnRideApp.Common;

namespace CollegeApp.Models.Dtos.RequestModels;

public class ApplicantRequest
{
    [Required(ErrorMessage = "Name is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    [RegularExpression(RegexPatterns.AlphaOnly, ErrorMessage = "Only Alphabet allowed!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Aadhar Number is required!")]
    [MinLength(10, ErrorMessage = "Aadhar number must have 10 character!")]
    [MaxLength(10, ErrorMessage = "Only 10 character allowed!")]
    [RegularExpression(RegexPatterns.NumberOnly, ErrorMessage = "Only numbers allowed!")]
    public string AadharNo { get; set; }

    [Required(ErrorMessage = "Course is required!")]
    [MaxLength(50, ErrorMessage = "Only 50 character allowed!")]
    public string Course { get; set; }

    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Session year is required!")]
    [Range(2025, 2050, ErrorMessage = "Year is not in range!")]
    public int Session { get; set; }  // year for session

    [Required(ErrorMessage = "Email Id is required!")]
    [EmailAddress(ErrorMessage = "Email Id is not in correct format!")]
    [MaxLength(20, ErrorMessage = "Only 20 characters allowed!")]
    public string Email { get; set; }
}