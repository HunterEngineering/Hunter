using Hunter.API.Contracts;
using Hunter.API.Data;

namespace Hunter.API.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(HunterDbContext context) : base(context)
        {

        }
    }
}
