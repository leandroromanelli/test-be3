using Be3Test.Api.Models.Base;
using System;
using System.Collections.Generic;

namespace Be3Test.Api.Models
{
    public class PatientRequestModel : BaseRequestModel
    {
        public PatientRequestModel() : base()
        {
        }

        public string MedicalRecord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Genre { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UfRG { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }

        public List<InsuranceCardRequestModel> InsuranceCards { get; set; }

    }
}
