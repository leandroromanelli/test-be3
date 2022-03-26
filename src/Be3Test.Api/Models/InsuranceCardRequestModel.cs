using Be3Test.Api.Models.Base;
using System;
using System.ComponentModel;

namespace Be3Test.Api.Models
{
    public class InsuranceCardRequestModel : BaseRequestModel
    {
        public InsuranceCardRequestModel() : base()
        {
        }

        public Guid InsuranceId { get; set; }
        public Guid PatientId { get; set; }
        [DisplayName("Numero")]
        public string Number { get; set; }
        [DisplayName("Validade")]
        public DateTime Validity { get; set; }

    }
}
