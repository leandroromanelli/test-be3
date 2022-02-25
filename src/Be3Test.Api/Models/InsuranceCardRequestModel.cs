using Be3Test.Api.Models.Base;
using System;

namespace Be3Test.Api.Models
{
    public class InsuranceCardRequestModel : BaseRequestModel
    {
        public InsuranceCardRequestModel() : base()
        {
        }

        public Guid InsuranceId { get; set; }
        public string Number { get; set; }
        public DateTime Validity { get; set; }

    }
}
