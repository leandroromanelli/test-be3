using Be3Test.Api.Models.Base;
using System;
using System.ComponentModel;

namespace Be3Test.Api.Models
{
    public class InsuranceCardResponseModel : BaseResponseModel
    {
        public InsuranceCardResponseModel() : base()
        {
            Patient = new PatientResponseModel();
            Insurance = new InsuranceResponseModel();
        }

        public virtual PatientResponseModel Patient { get; set; }
        public virtual InsuranceResponseModel Insurance { get; set; }

        [DisplayName("Numero")]
        public string Number { get; set; }
        [DisplayName("Validade")]
        public DateTime Validity { get; set; }
        [DisplayName("Ativo")]
        public bool IsActive { get; set; }

    }
}
