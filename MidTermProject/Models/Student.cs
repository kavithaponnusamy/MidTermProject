using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidTermProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [AgeValidation]
        public DateTime? BirthDate { get; set; }

        public Course Course { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }

        [Display(Name ="Course Enrolled Date")]
        public DateTime CourseEnrolledDate { get; set; }

        [Required]
        [Display(Name ="Course Status")]
        public int CourseStatus { get; set; }

        [Required]
        public string Grade { get; set; }

    }
}