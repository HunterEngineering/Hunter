using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hunter.API.Data.Configurations
{
    public class GhostConfiguration : IEntityTypeConfiguration<Ghost>
    {
        public void Configure(EntityTypeBuilder<Ghost> builder)
        {
            builder.HasData(
                new Ghost
                {
                    Id = 1,
                    Era = 0,
                    isActive = true,
                    initialEra = "",
                    ProjectId = 1,
                    PopulationId = 1
                }
            );
        }
    }
}
