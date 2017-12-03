using StudentsMVC.Models;
using System.Collections.Generic;

namespace StudentsMVC.Services
{
    public class StudentService
    {
        public Dictionary<int, StudentModel> Students { get; }

        public StudentService()
        {
            Students = new Dictionary<int, StudentModel>();
        }
    }
}
