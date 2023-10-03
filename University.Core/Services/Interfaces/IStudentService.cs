
using Microsoft.AspNetCore.Mvc.Rendering;
using University.DataLayer.Entities;

namespace University.Core.Services.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        List<SelectListItem> GetLevelsForManageStudent();
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentForShow(int studentLevel);
        Student GetStudentById(int studentId);


    }
}
