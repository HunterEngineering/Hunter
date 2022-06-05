using System.ComponentModel.DataAnnotations;

namespace Hunter.API.DTOs
{
    public abstract class BaseCompanyDto
    {
        [Required]
        public string Name { get; set; }
        public string Billing { get; set; }
        public string Region { get; set; }

    }
}
