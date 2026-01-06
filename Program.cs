using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Versioning.Data;

var builder = WebApplication.CreateBuilder(args);

// Controllers FIRST (important)
builder.Services.AddControllers();

// EF Core
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// API Versioning (MVC)
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);

    //  MUST be false
    options.AssumeDefaultVersionWhenUnspecified = false;

    options.ReportApiVersions = true;

    //  THIS enables /v1, /v2
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
