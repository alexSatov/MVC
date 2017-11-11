using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class Student
    {
        [Required]
        public int Id       { get; set; }
        public int Mark     { get; set; }
        public string Name  { get; set; }
        public string Email { get; set; }
    }
}