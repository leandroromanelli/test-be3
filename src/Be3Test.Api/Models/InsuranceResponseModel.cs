using Be3Test.Api.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace Be3Test.Api.Models
{
    public class InsuranceResponseModel : BaseResponseModel
    {
        public InsuranceResponseModel() : base()
        {
            InsuranceCards = new List<InsuranceCardResponseModel>();
        }

        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Descricao")]
        public string Description { get; set; }
        public virtual List<InsuranceCardResponseModel> InsuranceCards { get; set; }

    }
}
