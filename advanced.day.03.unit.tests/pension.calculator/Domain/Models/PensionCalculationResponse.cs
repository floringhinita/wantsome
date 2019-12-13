namespace Domain.Models
{
    using System;

    public class PensionCalculationResponse
    {
        public Guid PersonId { get; set; }

        public bool IsPensionable { get; set; }
    }
}
