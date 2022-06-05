using System.ComponentModel.DataAnnotations;

namespace Hunter.API.DTOs
{
    public class GetCompanyDto : BaseCompanyDto
    {
        public int Id { get; set; }
    }
}
