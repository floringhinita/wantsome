namespace App.Domain.Services
{
    using System;

    namespace Domain.Services
    {
        using Core;
        using Entities;
        using Models;

        public interface IPensionService
        {
            PensionCalculationResponse Calculate(Guid personId);
        }

        public class PensionService : IPensionService
        {
            private readonly IMailService mailService;

            private readonly IPersonRepository repository;

            private readonly IClock clock;

            public PensionService(IPersonRepository repository, IMailService mailService, IClock clock)
            {
                this.repository = repository;

                this.mailService = mailService;

                this.clock = clock;
            }

            public PensionCalculationResponse Calculate(Guid personId)
            {
                var person = this.repository.Get(personId);

                var age = this.CalculateAge(person);

                if (age < 0)
                {
                    throw new ArgumentException("Age should not be negative!");
                }

                if (age < 40)
                {
                    return new PensionCalculationResponse { IsPensionable = false, PersonId = person.Id };
                }

                if (age >= 40 && age < 50)
                {
                    this.mailService.Send("at 51 you'll have pension :)", person.Email);

                    return new PensionCalculationResponse { IsPensionable = false, PersonId = person.Id };
                }

                this.mailService.Send("welcome to pension", person.Email);

                return new PensionCalculationResponse { IsPensionable = true, PersonId = person.Id };
            }

            private int CalculateAge(Person person)
            {
                return this.clock.Now().Year - person.DateOfBirth.Year;
            }
        }
    }

}
