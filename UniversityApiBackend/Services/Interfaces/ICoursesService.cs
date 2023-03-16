using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICoursesService
    {
        Task<IEnumerable<Course>> GetCoursesByCategory(int categoryId);
        Task<IEnumerable<Course>> GetCoursesWithNoChapter();
        Task<Chapter> GetCourseChapter(int courseId);
        Task<IEnumerable<Student>> GetCourseStudents(int courseId);
    }
}
