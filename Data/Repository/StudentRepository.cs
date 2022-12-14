using Data.Context;
using Data.Dto;
using Data.Entity;
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

        /*public TurmaDto PorId(int id)
        {
            return (from t in _contexto.Turmas
                    where t.Id == id
                    select new Dto.TurmaDto()
                    {
                        Chave = t.Id,
                        Nome = t.Nome
                    })
                    ?.FirstOrDefault()
                    ?? new TurmaDto();
        }

        public int Atualizar(TurmaCadastrarDto cadastrarDto)
        {
            Entidades.Turma turmaEntidadeBanco =
                (from c in _contexto.Turmas
                 where c.Id == cadastrarDto.Id
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidades.Turma();

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (turmaEntidadeBanco == null || DBNull.Value.Equals(turmaEntidadeBanco.Id) || turmaEntidadeBanco.Id == 0)
            {
                return 0;
            }

            Entidades.Turma turmaEntidade = new Entidades.Turma()
            {
                Nome = cadastrarDto.Nome,
                Descricao = cadastrarDto.Descricao,
                PeriodoInicio = cadastrarDto.PeriodoInicio,
                PeriodoFim = cadastrarDto.PeriodoFim
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Turmas.Add(turmaEntidade);
            return _contexto.SaveChanges();
        }

        public int Cadastrar(TurmaCadastrarDto cadastrarDto)
        {
            Entidades.Turma turmaEntidade = new Entidades.Turma()
            {
                Nome = cadastrarDto.Nome,
                Descricao = cadastrarDto.Descricao,
                PeriodoInicio = cadastrarDto.PeriodoInicio,
                PeriodoFim = cadastrarDto.PeriodoFim
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Turmas.Add(turmaEntidade);
            return _contexto.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Entidades.Turma turmaEntidadeBanco =
                (from c in _contexto.Turmas
                 where c.Id == Id
                 select c).FirstOrDefault();

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (turmaEntidadeBanco == null || DBNull.Value.Equals(turmaEntidadeBanco.Id) || turmaEntidadeBanco.Id == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Turmas.Remove(turmaEntidadeBanco);
            return _contexto.SaveChanges();
        }*/
    }
}
