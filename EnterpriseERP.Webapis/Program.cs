
using EnterpriseERP.Application.DTO.Company;
using EnterpriseERP.Application.DTO.Department;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Application.Mapping;
using EnterpriseERP.Application.Service;
using EnterpriseERP.Application.Validators.Department;
using EnterpriseERP.Insfrastructure.Data;
using EnterpriseERP.Insfrastructure.Identity;
using EnterpriseERP.Insfrastructure.Implementation;
using EnterpriseERP.Webapi.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace EnterpriseERP.Webapis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(BranchProfile));
            builder.Services.AddAutoMapper(typeof(CompanyMapping));
            builder.Services.AddAutoMapper(typeof(DepartmentProfile));
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateComapnyDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateComapnyDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateDepartmentValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateDepartmentValidator>();
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddIdentity<AppUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtService"],
                ValidAudience = builder.Configuration["Jwt:Auience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration
                    ["Jwt:Key"]!))
                };
            });
















            builder.Host.UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);
                });
            var app = builder.Build();
            app.UseSerilogRequestLogging();
           
            app.UseGlobalExceptionHandler();
            
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
        }
    }
}
