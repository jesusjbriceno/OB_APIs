namespace UniversityApiBackend.Services
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;

        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }
    }
}
