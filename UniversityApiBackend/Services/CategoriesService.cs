namespace UniversityApiBackend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ILogger<CategoriesService> _logger;

        public CategoriesService(ILogger<CategoriesService> logger)
        {
            _logger = logger;
        }
    }
}
