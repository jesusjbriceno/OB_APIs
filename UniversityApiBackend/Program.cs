// 1. usings to work with EF
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;
// 10. Use Serilog to log events
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 13. Consfig serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf
        .WriteTo.Console()
        .WriteTo.Debug()
        .ReadFrom.Configuration(hostBuilderCtx.Configuration);
});


// 2. Connection with SQL Server
const string CONNECTION_NAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);


// 3. Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


// 7. Add Servide of JWT Authorization
builder.Services.AddJwtTokenServices(builder.Configuration);

// 10. Add Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


// Add services to the container.

builder.Services.AddControllers();


// 4. Add Custom Services (folder services)
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IChaptersService, ChaptersService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IUsersService, UsersService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 8. Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// 9. Config Swagger to take care of Authorization of JWT
builder.Services.AddSwaggerGen(options =>
    {
        // We define the security for authorization
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization Header using Bearer Scheme"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                }, new string[]{ }
            }
        });
    }
);


// 5. CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});



var app = builder.Build();

// 11. Supported Cultures
var supportedCultures = new[] { "es-ES", "en-US", "fr-FR", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

// 12. Add localization to App
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 14. Teel app use Serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// 6. Teel app to use CORS
app.UseCors("CorsPolicy");

app.Run();
