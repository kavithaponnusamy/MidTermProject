using System.ComponentModel.DataAnnotations;

namespace MidTermProject.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string CourseDescription { get; set; }

        [Required]
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }

        [Required]
        [Display(Name = "Course Rating")]
        [Range(1,10)]
        public int CourseRating { get; set; }

    }
}