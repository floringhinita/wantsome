namespace Domain.Services
{
    using System;
    using Entities;
    using Models;

    public class PensionServiceV3
    {
        private readonly IPersonRepository repository;
        private readonly IMailSender mailSender;

        // TODO - remove DateTime.Now.Year dependency

        public PensionServiceV3(IPersonRepository repository, IMailSender mailSender)
        {
            this.repository = repository;
            this.mailSender = mailSender;
        }

        //scenarios to cover

        //if age < 40, do nothing, return PensionCalculationResponse.IsPensionable = false

        //if age > 40 && age < 50, return PensionCalculationResponse.IsPensionable = false,
            //but send and email containing "at 51 you'll have pension :)"

        // if age > 50, return return PensionCalculationResponse.IsPensionable = true,
            //and send an email containing "welcome to pension"

        // second scenarios
            // if leap year, each person has 2 year bonus when pension is calculated 

        public PensionCalculationResponse Calculate(Guid personId)
        {
            var person = this.repository.Get(personId);

            var age = this.CalculateAge(person);

            if (age < 40)
            {
                return new PensionCalculationResponse { IsPensionable = false, PersonId = person.Id };
            }

            if (age >= 40 && age < 50)
            {
                this.mailSender.Send("at 51 you'll have pension :)");

                return new PensionCalculationResponse { IsPensionable = false, PersonId = person.Id };
            }

            this.mailSender.Send("welcome to pension");

            return new PensionCalculationResponse { IsPensionable = true, PersonId = person.Id };
        }

        private int CalculateAge(Person person)
        {
            return DateTime.Now.Year - person.DateOfBirth.Year;
        }
    }
}
