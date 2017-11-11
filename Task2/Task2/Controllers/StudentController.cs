using System.Linq;
using System.Collections.Generic;
using Task2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class StudentController : Controller
    {
        private static readonly Dictionary<int, Student> students = new Dictionary<int, Student>();

        [HttpPut("/student")]
        public IActionResult Create(Student student)
        {
            if (students.Keys.Contains(student.Id))
                return BadRequest($"Student with ID = {student.Id} is already exist.");

            students[student.Id] = student;

            return Ok(student);
        }

        [HttpGet("/student/{id}")]
        public IActionResult Read(int id)
        {
            if (!students.Keys.Contains(id))
                return BadRequest($"Student with ID = {id} isn't exist.");

            return Ok(students[id]);
        }

        [HttpPost("/student")]
        public IActionResult Update(Student student)
        {
            if (!students.Keys.Contains(student.Id))
                return BadRequest($"Student with ID = {student.Id} isn't exist.");

            var updatedStudent   = students[student.Id];
            updatedStudent.Name  = student.Name  ?? updatedStudent.Name;
            updatedStudent.Email = student.Email ?? updatedStudent.Email;

            return Ok(updatedStudent);
        }

        [HttpDelete("/student/{id}")]
        public IActionResult Delete(int id)
        {
            if (!students.Keys.Contains(id))
                return BadRequest($"Student with ID = {id} isn't exist.");

            students.Remove(id);

            return Content($"Student with ID = {id} has been deleted.");
        }

        [HttpGet("/student/all")]
        public IActionResult GetAll()
        {
            return Ok(students);
        }
    }
}