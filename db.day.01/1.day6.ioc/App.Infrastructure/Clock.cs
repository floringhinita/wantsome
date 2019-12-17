namespace App.Infrastructure
{
    using System;
    using Domain.Core;

    public class Clock : IClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
