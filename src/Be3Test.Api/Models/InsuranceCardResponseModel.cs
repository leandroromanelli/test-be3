using Be3Test.Api.Models.Base;
using System;

namespace Be3Test.Api.Models
{
    public class InsuranceCardResponseModel : BaseResponseModel
    {
        public InsuranceCardResponseModel() : base()
        {
        }

        public PatientResponseModel Patient { get; set; }
        public InsuranceResponseModel Insurance { get; set; }

        public string Number { get; set; }
        public DateTime Validity { get; set; }
        public bool IsActive { get; set; }

    }
}
