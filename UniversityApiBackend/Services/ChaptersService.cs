namespace UniversityApiBackend.Services
{
    public class ChaptersService : IChaptersService
    {
        private readonly ILogger<ChaptersService> _logger;

        public ChaptersService(ILogger<ChaptersService> logger)
        {
            _logger = logger;
        }
    }
}
