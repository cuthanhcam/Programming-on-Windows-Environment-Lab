// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("\nMenu: ");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Display list of students");
                Console.WriteLine("4. Display list of teachers");
                Console.WriteLine("5. Number of studentList and teacherList");
                Console.WriteLine("6. Display students by faculty");
                Console.WriteLine("7. Display teachers by address (District 9)");
                Console.WriteLine("8. Display student with highest average score by faculty");
                Console.WriteLine("9. Count rank students");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose (0 - 9)");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        AddTeacher(teacherList);
                        break;
                    case "3":
                        DisplayStudentList(studentList);
                        break;
                    case "4":
                        DisplayTeacherList(teacherList);
                        break;
                    case "5":
                        CountStudentAndTeacher(studentList, teacherList);
                        break;
                    case "6":
                        DisplayStudentByFaculty(studentList, "IT");
                        break;
                    case "7":
                        DisplayTeacherByAddress(teacherList, "9");
                        break;
                    case "8":
                        DisplayStudentWithHighestAverageScoreByFaculty(studentList, "IT");
                        break;
                    case "9":
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
            Console.WriteLine("Import information of student");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Import successfully");
        }
        // case 2:
        static void AddTeacher(List<Teacher> teacherList)
        {
            Console.WriteLine("Import informatrion of teacher");
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Import succesfully");
        }
        // case 3:
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("List of students");
            foreach (var student in studentList)
            {
                student.Show();
            }
        }
        // case 4:
        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            Console.WriteLine("List of teachers");
            foreach (var teacher in teacherList)
            {
                teacher.Show();
            }
        }
        // case 5:
        static void CountStudentAndTeacher(List<Student> studentList, List<Teacher> teacherList)
        {
            Console.WriteLine($"Number of students: {studentList.Count}");
            Console.WriteLine($"Number of teachers: {teacherList.Count}");
        }
        // case 6:
        static void DisplayStudentByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"List of students in {faculty}");
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }
        // case 7:
        static void DisplayTeacherByAddress(List<Teacher> teacherLsit, string address)
        {
            Console.WriteLine($"List of teacher in {address}");
            var teachers = teacherLsit
                .Where(t => t.Address.Contains(address))
                .ToList();
            DisplayTeacherList(teachers);
        }
        // case 8:
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
        // case 9:
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
