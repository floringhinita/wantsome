namespace Domain.Entities
{
    using System;

    public class Person
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
