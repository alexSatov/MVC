using System.ComponentModel.DataAnnotations;

namespace StudentsMVC.Models
{
    public class Student
    {
        [Required]
        [Range(1, 100)]
        public int Id       { get; set; }

        [Range(0, 100)]
        public int? Mark    { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name  { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }
    }
}