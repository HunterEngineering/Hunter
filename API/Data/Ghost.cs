using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class Ghost : EntityBase
    {
        public Ghost()
        {

        }
        public int Era { get; set; }
        public bool isActive { get; set; }
        public string initialEra { get; set; }


        // ONE project can have MANY ghosts
        [ForeignKey("ProjectGhostId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }


        // ONE GHOST can have ONE Population
        public int PopulationId { get; set; }
        public virtual Population Population { get; set; }
    }
}
