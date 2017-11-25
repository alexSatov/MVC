using System.Linq;
using System.Collections.Generic;
using StudentsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        private static readonly StudentsModel model = new StudentsModel
        {
            Students = new Dictionary<int, StudentModel>()
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(model);
        }

        public IActionResult Add()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        public IActionResult Add(StudentModel student)
        {
            if (!ModelState.IsValid || model.Students.Keys.Contains(student.Id))
                return Add();

            model.Students[student.Id] = student;

            return RedirectToAction("GetAll", "Student");
        }

        public IActionResult Update()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        public IActionResult Update(StudentModel student)
        {
            if (!ModelState.IsValid || !model.Students.Keys.Contains(student.Id))
                return Update();

            var studentToUpdate   = model.Students[student.Id];
            studentToUpdate.Name  = student.Name  ?? studentToUpdate.Name;
            studentToUpdate.Email = student.Email ?? studentToUpdate.Email;
            studentToUpdate.Mark  = student.Mark  ?? studentToUpdate.Mark;

            return RedirectToAction("GetAll", "Student");
        }

        public IActionResult Delete()
        {
            return View(new IdModel { Id = 0 });
        }

        [HttpPost]
        public IActionResult Delete(IdModel idModel)
        {
            if (!model.Students.Keys.Contains(idModel.Id))
                return Delete();

            model.Students.Remove(idModel.Id);

            return RedirectToAction("GetAll", "Student");
        }
    }
}