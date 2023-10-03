
using Microsoft.AspNetCore.Mvc.Rendering;
using University.DataLayer.Entities;
namespace University.RestAPI.Services.Interfaces
{
    public interface IStudentAPIService
    {
        Task<Student> GetByIdAsync(int id);
        Task<Student> InsertStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<bool> StudentExist(int id);
        Task<List<Student>> GetAllAsync();


    }
}
