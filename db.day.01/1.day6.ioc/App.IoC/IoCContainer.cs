namespace App.IoC
{
    using System;
    using Domain;
    using Domain.Core;
    using Domain.Services;
    using Domain.Services.Domain.Services;
    using Infrastructure;
    using Infrastructure.Database;
    using Infrastructure.Logging;
    using Infrastructure.Mail;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using ILogger = Domain.Core.ILogger;

    public class IoCContainer
    {
        public ServiceProvider Build()
        {
            //setup our DI
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IClock, Clock>()
                .AddSingleton<ILogger, ConsoleLogger>()
                .AddSingleton<IMailSender, MailSender>()
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddScoped<IMailService, MailService>()
                .AddScoped<IPensionService, PensionService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
