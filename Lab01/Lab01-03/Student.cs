// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Student : Person
    {
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student() : base()
        {
            AverageScore = 0;
            Faculty = string.Empty;
        }

        public Student(string id, string fullName, float averageScore, string faculty) : base(id, fullName)
        {
            AverageScore = averageScore;
            Faculty = faculty;
        }

        public Student(Student other) : base(other)
        {
            AverageScore = other.AverageScore;
            Faculty = other.Faculty;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Import Average Score: ");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Import Faculty: ");
            Faculty = Console.ReadLine();
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Average Score: {this.AverageScore}, Faculty: {this.Faculty}");
        }
    }
}
