using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentsMVC.Models;

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        private static readonly Dictionary<int, Student> students = new Dictionary<int, Student>();
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        [HttpPut("/student")]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (students.Keys.Contains(student.Id))
                return BadRequest($"Student with ID = {student.Id} is already exist.");

            students[student.Id] = student;

            return Json(student, settings);
        }

        [HttpGet("/student/{id}")]
        public IActionResult Read(int id)
        {
            if (!students.Keys.Contains(id))
                return BadRequest($"Student with ID = {id} isn't exist.");

            return Json(students[id], settings);
        }

        [HttpPost("/student")]
        public IActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!students.Keys.Contains(student.Id))
                return BadRequest($"Student with ID = {student.Id} isn't exist.");

            var studentToUpdate = students[student.Id];
            studentToUpdate.Name  = student.Name  ?? studentToUpdate.Name;
            studentToUpdate.Email = student.Email ?? studentToUpdate.Email;
            studentToUpdate.Mark  = student.Mark  ?? studentToUpdate.Mark;

            return Json(studentToUpdate, settings);
        }

        [HttpDelete("/student/{id}")]
        public IActionResult Delete(int id)
        {
            if (!students.Keys.Contains(id))
                return BadRequest($"Student with ID = {id} isn't exist.");

            students.Remove(id);

            return Ok($"Student with ID = {id} has been deleted.");
        }

        [HttpGet("/student/all")]
        public IActionResult GetAll()
        {
            return Json(students, settings);
        }
    }
}