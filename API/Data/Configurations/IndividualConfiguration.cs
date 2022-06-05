using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hunter.API.Data.Configurations
{
    public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.HasData(
                new Individual
                {
                    Id = 1,
                    PopulationId = 1,
                }
            );
        }
    }
}
