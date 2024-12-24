using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.BUS
{
    public class FacultyService
    {
        public List<Faculty> GetAll()
        {
            StudentModel context = new StudentModel();
            return context.Faculties.ToList();
        }
        // Tìm kiếm Khoa theo ID
        public Faculty FindById(int facultyID)
        {
            StudentModel context = new StudentModel();
            return context.Faculties.FirstOrDefault(f => f.FacultyID == facultyID);
        }

        // Thêm hoặc cập nhật Khoa
        public void InsertUpdate(Faculty faculty)
        {
            StudentModel context = new StudentModel();
            var existingFaculty = context.Faculties.FirstOrDefault(f => f.FacultyID == faculty.FacultyID);

            if (existingFaculty != null)
            {
                // Cập nhật thông tin nếu khoa đã tồn tại
                existingFaculty.FacultyName = faculty.FacultyName;
            }
            else
            {
                // Thêm khoa mới
                context.Faculties.Add(faculty);
            }

            context.SaveChanges();
        }

        // Xóa Khoa
        public void Delete(int facultyID)
        {
            StudentModel context = new StudentModel();
            var faculty = context.Faculties.FirstOrDefault(f => f.FacultyID == facultyID);

            if (faculty != null)
            {
                context.Faculties.Remove(faculty);
                context.SaveChanges();
            }
        }
    }
}
