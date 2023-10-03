using University.DataLayer.Entities;
using University.DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Core.Services.Interfaces
{
    public class StudentService:IStudentService
    {
        private UniversityContext _context;

        public StudentService(UniversityContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            student.RegisterDate= DateTime.Now;
            _context.Add(student);
            _context.SaveChanges();
            //return student.StudentId;

        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }
        public Student GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentForShow(int studentLevel)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetLevelsForManageStudent()
        {
            return _context.StudentLevels
                .Select(s => new SelectListItem()
                {
                    Text = s.LevelTitle,
                    Value = s.LevelId.ToString()
                })
                .ToList();
        }

       
    }
}
