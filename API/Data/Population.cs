using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class Population
    {
        public Population()
        {

        }
        public int Id { get; set; }
        public int Evolution { get; set; }


        // ONE Population has MANY Individuals
        public virtual IList<Individual> Individuals { get; set; }

        // One Ghost has ONE Population
        [ForeignKey(nameof(Ghost))]
        public int? GhostId { get; set; }
        public virtual Ghost Ghost { get; set; }
    }
}
