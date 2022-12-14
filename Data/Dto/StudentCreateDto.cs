namespace Data.Dto
{
    internal class StudentCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Matriculation { get; set; }
        public string? Document { get; set; }

    }
}
