namespace App.Domain.Core
{
    using System;

    public interface IClock
    {
        DateTime Now();
    }
}