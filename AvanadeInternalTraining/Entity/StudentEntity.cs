namespace AvanadeInternalTraining.Entity
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Matriculation { get; set; }
        public string Document { get; set; }
    }
}
