using Asp.Versioning;
using Asp.Versioning.Conventions;
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
    //options.ApiVersionReader = new UrlSegmentApiVersionReader();
    //options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
    //options.ApiVersionReader = new HeaderApiVersionReader("api-version");
    //options.ApiVersionReader = new MediaTypeApiVersionReader("v");
    options.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader("api-version"),
       new HeaderApiVersionReader("api-version"),
       new MediaTypeApiVersionReader("v")
       );
})
    //.AddMvc(options =>
    //{
    //    options.Conventions.Add(new VersionByNamespaceConvention());
    //})
    ;
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
