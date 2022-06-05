using Hunter.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hunter.API.Data
{
    public class HunterDbContext : IdentityDbContext<ApiUser>
    {
        public HunterDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Company> Companys { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ghost> Ghosts { get; set; }
        public DbSet<Population> Population { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder )
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfiguration(new RoleConfiguration());

            modelbuilder.ApplyConfiguration(new CompanyConfiguration());
            modelbuilder.ApplyConfiguration(new ProjectConfiguration());
            modelbuilder.ApplyConfiguration(new GhostConfiguration());
            modelbuilder.ApplyConfiguration(new PopulationConfiguration());
            modelbuilder.ApplyConfiguration(new IndividualConfiguration());
            modelbuilder.ApplyConfiguration(new FeatureConfiguration());
        }

    }
}
