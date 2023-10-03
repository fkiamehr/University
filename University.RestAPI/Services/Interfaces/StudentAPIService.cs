using Microsoft.EntityFrameworkCore;
using University.DataLayer.Context;
using University.DataLayer.Entities;

namespace University.RestAPI.Services.Interfaces
{
    public class StudentAPIService : IStudentAPIService
    {
        private readonly UniversityContext _context;

        public StudentAPIService(UniversityContext context)
        {
            _context = context;
        }

        public async Task DeleteStudentAsync(int id)
        {
            _context.Remove(new Student { StudentId = id });
            await _context.SaveChangesAsync();

        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentId == id);
        }
        public async Task<Student> InsertStudentAsync(Student student)
        {
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> StudentExist(int id)
        {
            return await _context.Students.AnyAsync(x => x.StudentId == id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
