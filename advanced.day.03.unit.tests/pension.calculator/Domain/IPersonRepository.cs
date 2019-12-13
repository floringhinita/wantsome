using System;

namespace Domain
{
    using Entities;

    public interface IPersonRepository
    {
        Person Get(Guid id);
    }
}
