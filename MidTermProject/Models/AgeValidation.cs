using System;
using System.ComponentModel.DataAnnotations;

namespace MidTermProject.Models
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;
            var age = DateTime.Today.Year - student.BirthDate.Value.Year;
            if (student.BirthDate == null)
                return new ValidationResult("Birthdate is required");
            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Student sholud be at least 18 years old!");

        }
    }
}