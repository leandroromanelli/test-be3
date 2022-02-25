using System;

namespace Be3Test.Domain.Entities
{
    public class InsuranceCard : BaseEntity
    {
        public InsuranceCard() : base()
        {
            IsActive = true;
        }

        public string Number { get; set; }
        public DateTime Validity { get; set; }
        public Guid PatientId { get; set; }
        public Guid InsuranceId { get; set; }
        public bool IsActive { get; set; }

        public Patient Patient { get; set; }
        public Insurance Insurance { get; set; }

        internal void Deactivate()
        {
            IsActive = false;
        }
    }
}
