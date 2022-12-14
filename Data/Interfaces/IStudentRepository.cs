namespace Data.Interfaces
{
    // Interface tem a declação do método
    public interface IStudentRepository
    {
        List<Dto.StudentDto> GetAll();
    }
}
