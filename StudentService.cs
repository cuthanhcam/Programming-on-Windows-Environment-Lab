﻿using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.BUS
{
    public class StudentService
    {
        public List<Student> GetAll()
        {
            StudentModel context = new StudentModel();
            return context.Students.ToList();
        }
        public List<Student> GetAllHasNoMajor()
        {
            StudentModel context = new StudentModel();
            return context.Students.Where(p => p.MajorID == null).ToList();
        }

        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            StudentModel context = new StudentModel();
            return context.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).ToList();
        }
        public List<Student> GetAllHasNoMajor(int facultyID, int MajorID)
        {
            using (StudenModel context = new StudentModel())
            {
                return context.Students
                              .Include(s => s.Faculty) // Bao gồm thông tin về Faculty
                              .Where(s => s.FacultyID == facultyID && (s.MajorID == null || s.MajorID != MajorID))
                              .ToList();
            }
        }
        public void DeleteStudent(string studentId)
        {
            using (StudentModel context = new StudentModel())
            {
                Student studentToDelete = context.Students.FirstOrDefault(s => s.StudentID == studentId);
                if (studentToDelete != null)
                {
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy sinh viên có MSSV: " + studentId);
                }
            }
        }
        public Student FindById(string studentId)
        {
            StudentModel context = new StudentModel();
            return context.Students.FirstOrDefault(p => p.StudentID == studentId);
        }
        public void InsertUpdate(Student s)
        {
            StudentModel context = new StudentModel();
            context.Students.AddOrUpdate(s);
            context.SaveChanges();
        }
    }
}
