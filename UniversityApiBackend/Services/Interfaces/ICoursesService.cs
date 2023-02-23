using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICoursesService
    {
        IEnumerable<Course> GetCoursesByCategory(int categoryId);
        IEnumerable<Course> GetCoursesWithNoChapter();
        Chapter GetCourseChapter(int courseId);
        IEnumerable<Student> GetCourseStudents(int courseId);
    }
}
