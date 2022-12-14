namespace Data.Interfaces
{
    // Interface tem a declação do método
    public interface IStudentRepository
    {
        List<Dto.StudentDto> GetAll();
        Dto.StudentDto GetOne(int id);
        int Create(Dto.StudentCreateDto student);
        int Update(Dto.StudentCreateDto student);
        int Delete(int Id);
    }
}
