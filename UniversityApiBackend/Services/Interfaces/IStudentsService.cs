using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetStudentsWithCourses();
        Task<IEnumerable<Student>> GetStudentsWithNoCourses();
        Task<IEnumerable<Course>> GetStudentCourses(int studentId);
    }
}
