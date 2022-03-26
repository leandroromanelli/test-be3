using Be3Test.Api.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace Be3Test.Api.Models
{
    public class InsuranceRequestModel : BaseRequestModel
    {
        public InsuranceRequestModel() : base()
        {
        }

        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Descricao")]
        public string Description { get; set; }

    }
}
