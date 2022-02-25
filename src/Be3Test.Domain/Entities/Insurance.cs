using System.Collections.Generic;

namespace Be3Test.Domain.Entities
{
    public class Insurance : BaseEntity
    {
        public Insurance() : base()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<InsuranceCard> InsuranceCards { get; set; }

    }
}
