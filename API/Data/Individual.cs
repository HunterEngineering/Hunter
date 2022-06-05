using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class Individual
    {
        public Individual()
        {
                
        }
        public int Id { get; set; }
        public double Fitness { get; set; }
        public int Generations { get; set; }
        public int PopulationPosition { get; set; }
#nullable disable

        [ForeignKey(nameof(PopulationId))]
        public int? PopulationId { get; set; }
        public virtual Population Population { get; set; }

        // MANY Individuals have MANY Features
        //public virtual IList<Feature> Features { get; set; }

    }
}
