using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Domain.Validators;
using PhoneBook.Infra.Data.Context;
using PhoneBook.Infra.Data.Interfaces;
using PhoneBook.Infra.Data.Repository;

namespace PhoneBook.Infra.IoC
{
    public class DependencyContainer
    {
        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Data
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddDbContext<DbContext, PhoneBookContext>(options => options.UseNpgsql(connectionString));
            services.AddTransient<IPhonebookRepository, PhonebookRepository>();
            services.AddTransient<IPhonebookEntryRepository, PhonebookEntryRepository>();

            //Application
            services.AddTransient<IPhoneBookService, PhoneBookService>();
           

            //Domain
            services.AddTransient<IValidator<Entry>, EntryValidator>();

            return services;
        }
    }
}
