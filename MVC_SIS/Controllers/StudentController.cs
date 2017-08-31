using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;
using System.Reflection.Metadata;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
			
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
			studentVM.Student.Courses = new List<Course>();

			foreach ( var id in studentVM.SelectedCourseIds )
				studentVM.Student.Courses.Add(CourseRepository.Get(id));

			if (ModelState.IsValid)
			{
				

				studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

				StudentRepository.Add(studentVM.Student);

				return RedirectToAction("List");
			}
			else
			{
				return View("Add", studentVM);
			}


		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			StudentVM studentVM = new StudentVM();
			studentVM.Student = StudentRepository.Get(id);
			studentVM.SetCourseItems(CourseRepository.GetAll());
			studentVM.SetMajorItems(MajorRepository.GetAll());
			studentVM.SetStateItems(StateRepository.GetAll());

			return View(studentVM);
		}

		[HttpPost]
		public ActionResult Edit(StudentVM studentVM)
		{
			studentVM.Student.Courses = new List<Course>();

			foreach ( var id in studentVM.SelectedCourseIds )
				studentVM.Student.Courses.Add(CourseRepository.Get(id));


			if ( ModelState.IsValid )
			{
				

				studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
				StudentRepository.Edit(studentVM.Student);
				return RedirectToAction("List");
			}
			else
			{
				return View("Edit", studentVM);
			}
		}
	

		[HttpPost]
		public ActionResult SaveAddress(StudentVM studentVM)
		{
			if ( ModelState.IsValid )
			{
				// here we would save the appointment to a database
				StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
				return RedirectToAction("List");
			}
			else
			{
				return View("Edit", studentVM);
			}
		}
		
	 

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var student = StudentRepository.Get(id);
			return View(student);
		}

		[HttpPost]
		public ActionResult Delete(Student student)
		{
			StudentRepository.Delete(student.StudentId);
			return RedirectToAction("List");
		}
	}
}