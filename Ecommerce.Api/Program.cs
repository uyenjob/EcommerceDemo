
using Ecommerce.Application;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mappings;
using Ecommerce.Application.Services;
using Ecommerce.Application.Validators;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure SQL Server DbContext
            var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
            builder.Services.AddDbContext<EcommerceDbContext>(options => options.UseSqlServer(connectionString));

            // Register IEcommerceDbContext
            builder.Services.AddScoped<IEcommerceDbContext>(provider => provider.GetRequiredService<EcommerceDbContext>());

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            // Email sender
            builder.Services.AddSingleton<IEmailSender, EmailSender>();

            // Register MediatR for Commands, Queries, Events
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            // Register FluentValidation
            builder.Services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Add services to the container.
            builder.Services.AddControllers();
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
        }
    }
}
