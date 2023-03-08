using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ILogger<CoursesService> _logger;

        public CoursesService(ILogger<CoursesService> logger)
        {
            _logger = logger;
        }

        public Chapter GetCourseChapter(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetCourseStudents(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesWithNoChapter()
        {
            throw new NotImplementedException();
        }
    }
}
