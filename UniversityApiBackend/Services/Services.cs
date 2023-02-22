using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class Services : IServices
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            this._context = context;
        }

        // -> UserService
        public User GetUserByEmail(string email)
            => _context.Users!.First(user => user.Email == email);

        
        // -> StudentService
        public IEnumerable<Student> GetAdultStudents()
            => _context.Students!.Where(student => student.Dob <= DateTime.Now.AddYears(18));

        public IEnumerable<Student> GetStudentsWithAtLeastOneCourse()
            => _context.Students!.Where(student => student.Courses.Any());
        
        // -> CourseService
        public IEnumerable<Course> GetCoursesForLevelWithStudents(EnumLevel level)
            => _context.Courses!.Where(course => course.Level == level && course.Students.Any());

        public IEnumerable<Course> GetCoursesForLevelInCategory(EnumLevel level, Category category)
            => _context.Courses!.Where(course => course.Level == level && course.Categories.Contains(category));

        public IEnumerable<Course> GetCoursesWithoutStudents()
            => _context.Courses!.Where(course => !course.Students.Any());
    }
}
