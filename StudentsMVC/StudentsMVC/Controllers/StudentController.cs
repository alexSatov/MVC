using System.Linq;
using StudentsMVC.Models;
using StudentsMVC.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext studentContext;

        public StudentController(StudentContext studentContext)
        {
            this.studentContext = studentContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = HttpContext.RequestServices.GetService<Student>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (!ModelState.IsValid || studentContext.Students.Any(s => s.Id == student.Id))
                return Add();

            studentContext.Students.Add(student);
            studentContext.SaveChanges();

            return RedirectToAction("GetAll", "Student");
        }

        public IActionResult Update()
        {
            var model = HttpContext.RequestServices.GetService<Student>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (!ModelState.IsValid || !studentContext.Students.Any(s => s.Id == student.Id))
                return Update();

            var studentToUpdate = studentContext.Students.First(s => s.Id == student.Id);

            studentToUpdate.Name  = student.Name  ?? studentToUpdate.Name;
            studentToUpdate.Mark  = student.Mark  ?? studentToUpdate.Mark;
            studentToUpdate.Email = student.Email ?? studentToUpdate.Email;
            studentToUpdate.Phone = student.Phone ?? studentToUpdate.Phone;

            studentContext.Update(studentToUpdate);
            studentContext.SaveChanges();

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
            var student = studentContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return Delete();

            studentContext.Students.Remove(student);
            studentContext.SaveChanges();

            return RedirectToAction("GetAll", "Student");
        }
    }
}