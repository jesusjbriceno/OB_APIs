using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();
        IEnumerable<Course> GetStudentCourses(int studentId);
    }
}
