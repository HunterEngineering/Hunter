using System.ComponentModel.DataAnnotations;

namespace Hunter.API.DTOs
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Designer { get; set; }
        public string Runner { get; set; }

        public int CompanyId { get; set; }
    }
}
