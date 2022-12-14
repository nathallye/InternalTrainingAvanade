namespace Data.Dto
{
    public class ClassDto
    {
        // DTO para mascarar as entidades para não retorná-las diretamente
        public int Key { get; set; }
        public string Name { get; set; } = null!;
    }
}
