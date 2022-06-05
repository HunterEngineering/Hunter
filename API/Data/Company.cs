using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class Company : EntityBase
    {
        public Company()
        {

        }

        public string Name { get; set; } // Name, Dept, Group, or Person responsible for billing
        public string Region { get; set; }
        public string BillingPerson { get; set; }
        public string Address { get; set; }
        public string Method { get; set; }
        public string AccountId { get; set; }
        public DateTime StartChargeableSvcs { get; set; }
        public DateTime NextChargeOccurs { get; set; }


        // ONE company with MANY projects
        public virtual IList<Project> Projects { get; set; }
    }
}
