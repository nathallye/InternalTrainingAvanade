using Data.Context;
using Data.Dto;
using Data.Interfaces;

namespace Data.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AvanadeInternalTrainingContext _context;

        public ClassRepository(AvanadeInternalTrainingContext context)
        {
            _context = context;
        }

        public List<ClassDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
