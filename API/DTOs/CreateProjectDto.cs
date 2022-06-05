using System.ComponentModel.DataAnnotations;

namespace Hunter.API.DTOs
{
    public class CreateProjectDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Designer { get; set; }
        public string Runner { get; set; }
    }
}
