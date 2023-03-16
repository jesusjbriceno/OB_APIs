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

        public async Task<Chapter> GetCourseChapter(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetCourseStudents(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCoursesWithNoChapter()
        {
            throw new NotImplementedException();
        }
    }
}
