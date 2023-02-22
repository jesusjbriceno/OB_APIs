using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IServices
    {
        // -> IUserService
        User GetUserByEmail(string email);

        // -> IStudentService
        IEnumerable<Student> GetAdultStudents();
        IEnumerable<Student> GetStudentsWithAtLeastOneCourse();

        // -> ICourseService
        IEnumerable<Course> GetCoursesForLevelWithStudents(EnumLevel level);
        IEnumerable<Course> GetCoursesForLevelInCategory(EnumLevel level, Category category);
        IEnumerable<Course> GetCoursesWithoutStudents();
    }
}
