using Exercises.Models.Data;
using Exercises.Models.Repositories;
using Exercises.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.Binders
{
    public class StudentVMBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var student = new StudentVM();
            student.SetCourseItems(CourseRepository.GetAll());
            student.SetMajorItems(MajorRepository.GetAll());
            student.SetStateItems(StateRepository.GetAll());
            student.Student = new Student
            {
                Major = MajorRepository.Get(int.Parse(request.Form["MajorId"])),
                GPA = decimal.Parse(request.Form["GPA"]),
                StudentId = int.Parse(request.Form["StudentId"]),
                FirstName = request.Form["FirstName"],
                LastName = request.Form["LastName"],
            };
            throw new NotImplementedException("Abandoned for the moment");
        }
    }
}