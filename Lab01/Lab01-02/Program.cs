// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("\nMenu: ");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Display list of students");
                Console.WriteLine("3. Display students by faculty");
                Console.WriteLine("4. Display student with greater Average score (5)");
                Console.WriteLine("5. Sorted student by average score");
                Console.WriteLine("6. Display student by faculty and score");
                Console.WriteLine("7. Display student with highest average score by faculty ");
                Console.WriteLine("8. Count rank students");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose (0 - 8) :");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "IT");
                        break;
                    case "4":
                        DisplayStudentWithGreaterAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortedStudentByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentByFacultyAndScore(studentList, "IT", 5);
                        break;
                    case "7":
                        DisplayStudentWithHighestAverageScoreByFaculty(studentList, "IT");
                        break;
                    case "8":
                        CountRankStudents(studentList);
                        break;
                    case "0":
                        flag = true;
                        Console.WriteLine("End of program");
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again");
                        break;  
                }
            }
        }

        // case 1:
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("Import information of students: ");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Import successfully");
        }
        // case 2:
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("List of students");
            foreach (var student in studentList)
            {
                student.Show();
            }
        }
        // case 3:
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"List of students in {faculty}");
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }
        // case 4:
        static void DisplayStudentWithGreaterAverageScore(List<Student> studenList, float score)
        {
            Console.WriteLine($"List of students with score greater than {score}");
            var students = studenList
                .Where(s => s.AverageScore >= score)
                .ToList();
            DisplayStudentList(students);
        }
        //case 5:
        static void SortedStudentByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("List of students sorted by average score");
            var sortedStudents = studentList
                .OrderBy(s => s.AverageScore)
                .ToList();
            DisplayStudentList(sortedStudents);
        }
        // case 6:
        static void DisplayStudentByFacultyAndScore(List<Student> studentList, string faculty, float score)
        {
            Console.WriteLine($"List of students with score greater than {score} and in {faculty}");
            var students = studentList
                .Where(s => s.AverageScore >= score && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }
        // case 7:
        static void DisplayStudentWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"List of students with the highest average score and in faculty {faculty}");
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty))
                .GroupBy(s => s.AverageScore)
                .OrderByDescending(key => key.Key)
                .FirstOrDefault()
                .ToList();
            DisplayStudentList(students);
        }
        // case 8:
        static void CountRankStudents(List<Student> studentList)
        {
            var rank = studentList
                .GroupBy(s =>
                {
                    if (s.AverageScore >= 9.0) return "Excellent";
                    else if (s.AverageScore >= 8.0) return "Good";
                    else if (s.AverageScore >= 7.0) return "Fair";
                    else if (s.AverageScore >= 5.0) return "Average";
                    else if (s.AverageScore >= 4.0) return "Poor";
                    else return "Very Poor";
                })
                .Select(g => new { Rank = g.Key, Count = g.Count() })
                .OrderBy(x => x.Rank);
            Console.WriteLine("Number of students by type of ranking");
            foreach (var item in rank)
            {
                Console.WriteLine($"{item.Rank}: {item.Count}");
            }
        }
    }
}
