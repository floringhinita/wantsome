using System;

namespace App.StartPoint
{
    using Domain.Services.Domain.Services;
    using IoC;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new IoCContainer().Build();

            var service = container.GetService<IPensionService>();

            service.Calculate(Guid.NewGuid());
        }
    }
}
