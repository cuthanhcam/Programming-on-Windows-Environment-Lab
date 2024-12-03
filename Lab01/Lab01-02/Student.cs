// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student()
        {
            StudentId = string.Empty;
            FullName = string.Empty;
            AverageScore = 0;
            Faculty = string.Empty;
        }

        public Student(string studentId, string fullName, float averageScore, string faculty)
        {
            StudentId = studentId;
            FullName = fullName;
            AverageScore = averageScore;
            Faculty = faculty;
        }

        public Student(Student student)
        {
            StudentId = student.StudentId;
            FullName = student.FullName;
            AverageScore = student.AverageScore;
            Faculty= student.Faculty;
        }

        public void Input()
        {
            Console.Write("Import Student Id: ");
            StudentId = Console.ReadLine();
            Console.Write("Import Fullname: ");
            FullName = Console.ReadLine();
            Console.Write("Import Average Score: ");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Import Faculty: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine($"Id: {this.StudentId}, FullName: {this.FullName}, Average Score: {this.AverageScore}, Faculty: {this.Faculty}");
        }
    }
}
