using CollegeApp.Common;
using CollegeApp.Data;
using CollegeApp.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<CollegeDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeDbConnectionString")));

builder.Services.AddControllers();

builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<IApplicantRepo, ApplicantRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStaffRepo, StaffRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();