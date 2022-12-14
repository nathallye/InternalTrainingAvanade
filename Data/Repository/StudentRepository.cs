using Data.Context;
using Data.Dto;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AvanadeInternalTrainingContext _context;

        public StudentRepository(AvanadeInternalTrainingContext context)
        {
            _context = context;
        }

        public List<StudentDto> GetAll()
        {
            return _context.Students.Select(s => new StudentDto()
            {
                Key = s.Id,
                Name = s.Name,
                LastName = s.LastName
            }).ToList();
        }

        public StudentDto GetOne(int id)
        {
            return (from t in _context.Students
                    where t.Id == id
                    select new StudentDto()
                    {
                        Key = t.Id,
                        Name = t.Name,
                        LastName = t.LastName

                    })
                    ?.FirstOrDefault()
                    ?? new StudentDto();
        }

        public int Create(StudentCreateDto student)
        {
            StudentEntity studentEntity = new StudentEntity()
            {
                Name = student.Name,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Matriculation = student.Matriculation,
                Document = student.Document
            };

            _context.ChangeTracker.Clear();
            _context.Students.Add(studentEntity);
            return _context.SaveChanges();
        }

        public int Update(StudentCreateDto student)
        {
            StudentEntity studentEntityDB =
                (from c in _context.Students
                 where c.Id == student.Id
                 select c)
                 ?.FirstOrDefault()
                 ?? new StudentEntity();

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (studentEntityDB == null || DBNull.Value.Equals(studentEntityDB.Id) || studentEntityDB.Id == 0)
            {
                return 0;
            }

            StudentEntity studentEntity = new StudentEntity()
            {
                Name = student.Name,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Matriculation = student.Matriculation,
                Document = student.Document
            };

            _context.ChangeTracker.Clear();
            _context.Students.Add(studentEntity);
            return _context.SaveChanges();
        }

        public int Delete(int Id)
        {
            StudentEntity studentEntityDB =
                (from c in _context.Students
                 where c.Id == Id
                 select c).FirstOrDefault();

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (studentEntityDB == null || DBNull.Value.Equals(studentEntityDB.Id) || studentEntityDB.Id == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Students.Remove(studentEntityDB);
            return _context.SaveChanges();
        }
    }
}
