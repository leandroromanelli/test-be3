using Be3Test.Api.Models.Base;
using System.Collections.Generic;

namespace Be3Test.Api.Models
{
    public class InsuranceResponseModel : BaseResponseModel
    {
        public InsuranceResponseModel() : base()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<InsuranceCardResponseModel> InsuranceCards { get; set; }

    }
}
