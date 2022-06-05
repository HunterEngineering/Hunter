using Microsoft.AspNetCore.Identity;

namespace Hunter.API.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }

    }
}
