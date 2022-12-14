namespace Data.Entities
{
    public class ClassEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? InitialPeriod { get; set; }
        public DateTime? FinalPeriod { get; set; }
    }
}
