namespace App.Infrastructure.Logging
{
    using System;
    using Domain.Core;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}]: {message}");
        }
    }
}
