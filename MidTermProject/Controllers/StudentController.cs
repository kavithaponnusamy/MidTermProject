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
        // GET: Student
        public MidtermDbContext _context;

        public StudentController()
        {
            _context = new MidtermDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult List()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }
        public ActionResult Create()
        {
            var courseNames = _context.Courses.ToList();
            var viewModel = new StudentFormViewModel
            {
                Student = new Student(),
                Courses = courseNames
            };
            return View("StudentForm", viewModel);
        }

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