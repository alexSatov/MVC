using System.ComponentModel.DataAnnotations;

namespace StudentsMVC.Models
{
    public class StudentModel
    {
        [Required]
        [Range(1, 100)]
        [Display(Name = "№")]
        public int Id       { get; set; }

        [Range(0, 100)]
        [Display(Name = "Баллы")]
        public int? Mark    { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Display(Name = "Имя")]
        public string Name  { get; set; }

        [MaxLength(30)]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }
}