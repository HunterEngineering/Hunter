namespace Hunter.API.Data
{
    public class Feature : EntityBase
    {
        public Feature()
        {
        }

        public string Title { get; set; }
        public string Description { get; set; }


        public int? IndividualId { get; set; }
        public Individual Individual { get; set; }

    }
}
