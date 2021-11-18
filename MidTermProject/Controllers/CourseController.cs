using MidTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidTermProject.Controllers
{
    public class CourseController : Controller
    {
        public MidtermDbContext _context;

        public CourseController()
        {
            _context = new MidtermDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Course List
        public ActionResult List()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        //Opening the course form
        public ActionResult Create()
        {
            Course course = new Course();
            return View("CourseForm", course);
        }

        //1. Adding a new course record
        //2. Updating existing course record
        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (!ModelState.IsValid)
            {                
                return View("CourseForm");
            }
            if (course.Id == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(c => c.Id == course.Id);
                courseInDb.CourseName = course.CourseName;
                courseInDb.CourseDescription = course.CourseDescription;
                courseInDb.TutorName = course.TutorName;
                courseInDb.CourseRating = course.CourseRating;
            }
            _context.SaveChanges();
            return RedirectToAction("List", "Course");
        }

        //Getting the course record to edit
        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            return View("CourseForm", course);
        }

        //Deleting a course
        public ActionResult Delete(int id)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
                return HttpNotFound();
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("List", "Course");
        }

        public ActionResult Details(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            return View("Details", course);
        }
    }
}