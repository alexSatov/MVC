using System.ComponentModel.DataAnnotations;

namespace StudentsMVC.Models
{
    public class Student
    {
        [Key]
        [Required]
        [Range(1, 100)]
        [Display(Name = "№")]
        public int    Id    { get; set; }

        [Range(0, 100)]
        [Display(Name = "Баллы")]
        public int?   Mark  { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Display(Name = "Имя")]
        public string Name  { get; set; }

        [EmailAddress]
        [MaxLength(30)]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Phone]
        [MaxLength(12)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        protected bool Equals(Student other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}