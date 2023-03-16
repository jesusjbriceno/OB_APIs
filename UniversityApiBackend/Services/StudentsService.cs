using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly ILogger<StudentsService> _logger;

        public StudentsService(ILogger<StudentsService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Course>> GetStudentCourses(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
