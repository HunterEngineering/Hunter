using System.ComponentModel.DataAnnotations;

namespace Hunter.API.DTOs
{
    public class CompanyDto : BaseCompanyDto
    {
        public int Id { get; set; }
        [Required]

        public List<GetProjectDto> Projects { get; set; }
    }
}
