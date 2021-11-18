using MidTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MidTermProject.ViewModels;

namespace MidTermProject.Controllers
{
    public class StudentController : Controller
    {
        
        public MidtermDbContext _context;

        public StudentController()
        {
            _context = new MidtermDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Students List
        public ActionResult List()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }

        //Creating a new student record
        public ActionResult Create()
        {
            var courses = _context.Courses.ToList();
            var viewModel = new StudentFormViewModel
            {
                Student = new Student(),
                Courses = courses
            };
            return View("StudentForm", viewModel);
        }

        //1. Adding a new student record
        //2. Updating existing student record
        [HttpPost]
        public ActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel
                {
                    Student = student,
                    Courses = _context.Courses.ToList()

                };
                return View("StudentForm", viewModel);
            }
            if (student.Id == 0)
            {
                student.CourseEnrolledDate = DateTime.Now;
                _context.Students.Add(student);
            }
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.FirstName = student.FirstName;
                studentInDb.LastName = student.LastName;
                studentInDb.CourseId = student.CourseId;
                studentInDb.CourseStatus = student.CourseStatus;
                studentInDb.Grade = student.Grade;
            }
            _context.SaveChanges();
            return RedirectToAction("List", "Student");
        }

        //Getting the student record to edit
        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            var viewModel = new StudentFormViewModel
            {
                Student = student,
                Courses = _context.Courses.ToList()

            };
            return View("StudentForm", viewModel);

        }

        //Deleting a student record
        public ActionResult Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("List", "Student");
        }
    }
}