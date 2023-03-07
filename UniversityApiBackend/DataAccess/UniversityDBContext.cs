using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;


        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options) 
        { 
            _loggerFactory = loggerFactory;
        }

        // Add DbSets
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Chapter>? Indexes { get; set; }
        public DbSet<Student>? Students { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure Logger to EF
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            // optionsBuilder.LogTo(options => logger.Log(LogLevel.Information, options, new[] { DbLoggerCategory.Database.Name }));
            // optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }

}
