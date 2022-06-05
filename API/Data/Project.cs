using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class Project : EntityBase
    {
        public Project()
        {
            ProjectGhostId = Id;
        }

        public int ProjectGhostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Designer { get; set; }
        public string Runner { get; set; }


        // one company with many projects
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


        // ONE project can have MANY ghosts
        public virtual IList<Ghost> Ghosts { get; set; }

    }
}
