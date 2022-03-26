using Be3Test.Api.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Be3Test.Api.Models
{
    public class PatientRequestModel : BaseRequestModel
    {
        public PatientRequestModel() : base()
        {
            InsuranceCards = new List<InsuranceCardRequestModel>();
        }

        [DisplayName("Prontuario")]
        public string MedicalRecord { get; set; }
        [DisplayName("Nome")]
        public string FirstName { get; set; }
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Genero")]
        public string Genre { get; set; }
        [DisplayName("CPF")]
        public string CPF { get; set; }
        [DisplayName("RG")]
        public string RG { get; set; }
        [DisplayName("Uf do RG")]
        public string UfRG { get; set; }
        [DisplayName("e-Mail")]
        public string Email { get; set; }
        [DisplayName("Celular")]
        public string CellPhone { get; set; }
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DisplayName("Carteirinhas de Convenio")]
        public virtual List<InsuranceCardRequestModel> InsuranceCards { get; set; }

    }
}
