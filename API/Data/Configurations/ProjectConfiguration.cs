using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hunter.API.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = 1,
                    Designer = "Chuck Duncan",
                    Runner = "Buttons Duncan",
                    CompanyId = 1,
                    Title = "Sample Project"
                }
            );
        }
    }
}
