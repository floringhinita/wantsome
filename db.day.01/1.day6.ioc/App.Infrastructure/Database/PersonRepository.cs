namespace App.Infrastructure.Database
{
    using System;
    using Domain;
    using Domain.Entities;

    public class PersonRepository : IPersonRepository
    {
        public Person Get(Guid id)
        {
            // dummy implementation

            return new Person
            {
                DateOfBirth = DateTime.Today.AddYears(-60),
                Email = "andrei@mail.com",
                FullName = "Andrei",
                Id = Guid.NewGuid()
            };
        }
    }
}
