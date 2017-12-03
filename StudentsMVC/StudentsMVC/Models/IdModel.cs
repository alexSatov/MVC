using System.ComponentModel.DataAnnotations;

namespace StudentsMVC.Models
{
    public class IdModel
    {
        [Display(Name = "№")]
        public int Id { get; set; }

        public IdModel(int id)
        {
            Id = id;
        }
    }
}
