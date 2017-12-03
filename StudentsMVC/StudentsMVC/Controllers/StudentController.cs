using System.Linq;
using StudentsMVC.Models;
using StudentsMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = HttpContext.RequestServices.GetService<StudentModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add([FromServices] StudentService studentService, StudentModel student)  //just for hw
        {
            if (!ModelState.IsValid || studentService.Students.Keys.Contains(student.Id))
                return Add();

            studentService.Students[student.Id] = student;

            return RedirectToAction("GetAll", "Student");
        }

        public IActionResult Update()
        {
            var model = HttpContext.RequestServices.GetService<StudentModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(StudentModel student)
        {
            if (!ModelState.IsValid || !studentService.Students.Keys.Contains(student.Id))
                return Update();

            var studentToUpdate   = studentService.Students[student.Id];
            studentToUpdate.Name  = student.Name  ?? studentToUpdate.Name;
            studentToUpdate.Email = student.Email ?? studentToUpdate.Email;
            studentToUpdate.Mark  = student.Mark  ?? studentToUpdate.Mark;

            return RedirectToAction("GetAll", "Student");
        }

        public IActionResult Delete()
        {
            var model = ActivatorUtilities.CreateInstance<IdModel>(HttpContext.RequestServices, 0);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!studentService.Students.Keys.Contains(id))
                return Delete();

            studentService.Students.Remove(id);

            return RedirectToAction("GetAll", "Student");
        }
    }
}