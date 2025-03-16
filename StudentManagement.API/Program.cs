using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentManagement.API.Services;
using StudentManagement.API.Settings;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.Configure<StudentDbSetting>(builder.Configuration.GetSection("StudentDbSetting"));
builder.Services.AddSingleton<IStudentDbSetting>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<StudentDbSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(builder.Configuration.GetConnectionString("StudentManagementDB")));

builder.Services.AddScoped<IStudentService, StudentService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();