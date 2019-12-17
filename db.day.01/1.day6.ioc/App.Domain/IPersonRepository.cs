namespace App.Domain
{
    using System;
    using Entities;

    public interface IPersonRepository
    {
        Person Get(Guid id);
    }
}