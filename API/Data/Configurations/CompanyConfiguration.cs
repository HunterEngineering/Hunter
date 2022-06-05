using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hunter.API.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Solution Hunter Engineering",
                    Region = "NewEngland",
                    BillingPerson = "Patch",
                    Address = "Accounting Office",
                    Method = "Auto Monthly Debit",
                    AccountId = "DebitCard goes here",
                    StartChargeableSvcs = DateTime.Now,
                    NextChargeOccurs = DateTime.Now.AddDays(30)

                }
            );
        }
    }
}
