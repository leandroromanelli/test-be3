using Be3Test.Api.Models.Base;
using System.Collections.Generic;

namespace Be3Test.Api.Models
{
    public class InsuranceRequestModel : BaseRequestModel
    {
        public InsuranceRequestModel() : base()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
